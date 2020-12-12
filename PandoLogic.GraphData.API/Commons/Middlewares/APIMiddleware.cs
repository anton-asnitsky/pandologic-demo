using Commons.Exceptions;
using Commons.Exceptions.Http;
using Commons.Exceptions.Service;
using Commons.Logging;
using Commons.Model.Outbound;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Middlewares
{
    public class APIMiddleware : MiddlewareBase
    {
        private readonly RequestDelegate _next;

        public APIMiddleware(
            RequestDelegate next,
            ILogger<APIMiddleware> logger) :
            base(logger)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            var request = await FormatRequest(context.Request);

            var correlationId = GetCorrelationId(context);

            var originalBodyStream = context.Response.Body;

            using var responseBody = new MemoryStream();

            context.Response.Body = responseBody;

            try { await _next(context); }
            
            #region BadRequestException
            catch (BadRequestException ex)
            {
                LogException(nameof(BadRequestException), ex,
                    new ApiLogEntry(context, ex.Message, StatusCodes.Status400BadRequest, correlationId));

                await Respond(context, StatusCodes.Status400BadRequest,
                    new ErrorResponse(correlationId, errorId: 400, errorCode: "BAD_REQUEST", "Invalid request"));
            }
            #endregion

            #region NotFoundException
            catch (NotFoundException ex)
            {
                LogException(nameof(NotFoundException), ex,
                    new ApiLogEntry(context, ex.Message, StatusCodes.Status404NotFound, correlationId));

                await Respond(context, StatusCodes.Status404NotFound,
                    new ErrorResponse(correlationId, errorId: 404, errorCode: "NOT_FOUND", "Entity was not found"));
            }
            #endregion


            #region Service Exceptions
            catch (SqlException ex)
            {
                LogException(nameof(InternalServerException), ex,
                    new ApiLogEntry(context, ex.Message, StatusCodes.Status500InternalServerError, correlationId));

                await RespondWithInternalServerException(context, correlationId);
            }


            #endregion


            #region InternalServerException / Exception
            catch (Exception ex) when (ex is InternalServerException || ex is Exception)
            {
                LogException(nameof(InternalServerException), ex,
                    new ApiLogEntry(context, ex.Message, StatusCodes.Status500InternalServerError, correlationId));

                await RespondWithInternalServerException(context, correlationId);
            }
            #endregion

            finally
            {
                stopWatch.Stop();

                var response = await FormatResponse(context.Response);

                var logEntry = new PerformanceLogEntry(
                    duration: stopWatch.ElapsedMilliseconds,
                    context,
                    requestBodyParams: request,
                    responseBodyParams: response,
                    correlationId: GetCorrelationId(context));

                LogPerformance(logEntry);

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task RespondWithInternalServerException(HttpContext context, string correlationId)
        {
            await Respond(context, StatusCodes.Status500InternalServerError,
                    new ErrorResponse(correlationId, errorId: 500, errorCode: "INTERNAL_ERROR", "Internal server error"));
        }

        private static string GetCorrelationId(HttpContext context)
        {
            var correlationId = context.Request.Query["correlationId"].ToString();
            return !string.IsNullOrEmpty(correlationId) ? correlationId : Guid.NewGuid().ToString();
        }

        private async Task Respond(HttpContext context, int status, ErrorResponse errorResponse)
        {
            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";

            if (errorResponse != null)
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorResponse), Encoding.UTF8);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            using var reader = new StreamReader(
                request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                leaveOpen: true);

            var requestBody = await reader.ReadToEndAsync();

            request.Body.Position = 0;

            return requestBody;
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var responseBody = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            return responseBody;
        }
    }
}

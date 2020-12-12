using Microsoft.AspNetCore.Http;

namespace Commons.Logging
{
    public class PerformanceLogEntry : LogEntryAbstract
    {
        public long Duration { get; }
        public string Path { get; }
        public string Query { get; }
        public string RequestBodyParams { get; set; }
        public IHeaderDictionary RequestHeaders { get; set; }
        public string ResponseBodyParams { get; set; }

        public PerformanceLogEntry(
            long duration, 
            HttpContext context, 
            string requestBodyParams, 
            string responseBodyParams, 
            string correlationId) : 
            base("Performance Analysis", correlationId)
        {
            Duration = duration;
            Path = context.Request.Path;
            Query = context.Request.QueryString.Value;
            RequestBodyParams = requestBodyParams;
            RequestHeaders = context.Request.Headers;
            ResponseBodyParams = responseBodyParams;
        }
    }
}

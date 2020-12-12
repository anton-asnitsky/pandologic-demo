using Microsoft.AspNetCore.Http;

namespace Commons.Logging
{
    public class ApiLogEntry : LogEntryAbstract
    {
        public int ErrorCode { get; }
        public string Path { get; }
        public string TraceId { get; }

        public ApiLogEntry(HttpContext context, string message, int errorCode, string correlationId) : 
            base(message, correlationId)
        {
            ErrorCode = errorCode;
            Path = context.Request.Path;
            TraceId = context.TraceIdentifier;
        }
    }
}

using Commons.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Middlewares
{
    public abstract class MiddlewareBase
    {
        protected ILogger<MiddlewareBase> MiddlewareLogger { get; }

        public MiddlewareBase(ILogger<MiddlewareBase> logger)
        {
            MiddlewareLogger = logger;
        }

        protected void LogException(string exceptionType, Exception ex, LogEntryAbstract logEntry) =>
            MiddlewareLogger.LogError("[ERROR]: {@ExceptionType}: {@Ex} | LogEntry: {@LogEntry}", exceptionType, ex, logEntry);

        protected void LogPerformance(LogEntryAbstract logEntry) =>
            MiddlewareLogger.LogInformation("[PERFORMANCE]: {@LogEntry}", logEntry);
    }
}

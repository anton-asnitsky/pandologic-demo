using System;

namespace Commons.Logging
{
    public abstract class LogEntryAbstract
    {
        public string LogMessage { get; }
        public string HostName
        {
            get
            {
                var computerName = Environment.GetEnvironmentVariable("COMPUTERNAME");
                var hostName = Environment.GetEnvironmentVariable("HOSTNAME");

                return !string.IsNullOrEmpty(computerName) ? computerName : hostName;
            }
        }
        public string CorrelationId { get; }

        public LogEntryAbstract(string logMessage, string correlationId)
        {
            LogMessage = logMessage;
            CorrelationId = correlationId;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.Extensions
{
    public static class SerilogExtensions
    {
        public static LoggerConfiguration ConfigureConsoleSink(
                this LoggerConfiguration loggerConfiguration, IConfiguration configuration)
        {
            var configSectionKey = "Serilog:ConsoleSink";
            var sinkEnabled = configuration[$"{configSectionKey}:SinkEnabled"].Equals(bool.TrueString, System.StringComparison.OrdinalIgnoreCase);

            if (sinkEnabled)
            {
                loggerConfiguration.WriteTo.Console(
                    theme: SystemConsoleTheme.Literate,
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                );
            }

            return loggerConfiguration;
        }
    }
}

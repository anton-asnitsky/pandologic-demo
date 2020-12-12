using Microsoft.Extensions.Configuration;

namespace Commons.Logging
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging(IConfiguration configuration) => SerilogConfiguration.ConfigureLogging(configuration);
    }
}

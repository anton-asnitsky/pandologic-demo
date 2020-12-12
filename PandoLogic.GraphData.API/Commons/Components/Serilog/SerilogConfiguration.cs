using Commons.Extensions;
using Microsoft.Extensions.Configuration;
using Serilog;

internal static class SerilogConfiguration
{
    public static void ConfigureLogging(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ConfigureConsoleSink(configuration)
            .CreateLogger();
    }
}
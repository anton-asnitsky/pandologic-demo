using Commons.Logging;
using DBMigration.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphData.Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = GetConfiguration();

            LoggingConfiguration.ConfigureLogging(configuration);

            Log.Information("DBMigration.Service has been initialized.");

            new GraphDataMigrator(configuration).Migrate();
        }

        private static IConfiguration GetConfiguration() =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
    }
}

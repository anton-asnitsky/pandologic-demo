using Commons.Components.SqlServer;
using Commons.Enums;
using GraphData.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Commons.Extensions.Startup
{
    internal static class ServiceConfigurationExtensions
    {
        public static void ConfigureCommonOptions(this IServiceCollection services, IConfiguration configuration)
        {
        }

        public static void ConfigureBucketServices(this IServiceCollection services)
        {
            
        }

        public static void ConfigureSqlServerDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionDict = new Dictionary<DatabaseConnectionTypes, string>();

            #region Configure Query Connection String
            var queryConnectionString = configuration.GetValue<string>("DBConfiguration:QueryConnectionString");

            if (!string.IsNullOrEmpty(queryConnectionString))
                connectionDict.Add(DatabaseConnectionTypes.Query, queryConnectionString);
            #endregion

            #region Configure Command Connection String
            var commandConnectionString = configuration.GetValue<string>("DBConfiguration:CommandConnectionString");

            if (!string.IsNullOrEmpty(commandConnectionString))
                connectionDict.Add(DatabaseConnectionTypes.Command, commandConnectionString);
            #endregion

            services.AddSingleton<IDictionary<DatabaseConnectionTypes, string>>(connectionDict);
            services.AddTransient<IDbConnectionFactory, DapperDbConnectionFactory>();
        }

        public static void ConfigureSwagger(this IServiceCollection services, string microserviceName)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = microserviceName,
                    Version = "v1",
                });

                options.CustomSchemaIds(x => x.FullName);
            });
        }
    }
}

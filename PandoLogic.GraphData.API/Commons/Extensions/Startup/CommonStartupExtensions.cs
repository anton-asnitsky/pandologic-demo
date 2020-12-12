using Commons.Middlewares;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;

namespace Commons.Extensions.Startup
{
    public static class CommonStartupExtensions
    {
        public static void RegisterCommonExtensions(IServiceCollection services, IConfiguration configuration, string microserviceName,
            Action<IMvcCoreBuilder> mvcCoreBuilderAction = null,
            Action<IMvcBuilder> mvcBuilderAction = null)
        {
            services.ConfigureSqlServerDatabase(configuration);
            services.RegisterCommonDataStores(configuration);
            services.RegisterCommonServices(configuration);
            services.RegisterCommonHostedServices(microserviceName);
            services.ConfigureCommonOptions(configuration);
            services.RegisterCommonApiServices(microserviceName, mvcCoreBuilderAction, mvcBuilderAction);
        }

        public static void RegisterCommonExtensions(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration, string microserviceName)
        {
            app.RegisterCommonMiddlewares();
            app.ConfigureHealthChecks();
            app.ConfigureExceptionPage(env);
            app.ConfigureSwagger(microserviceName);
            app.ConfigureApiControllers();
        }

        private static void RegisterCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks();
        }

        private static void RegisterCommonDataStores(this IServiceCollection services, IConfiguration configuration)
        {
        }

        private static void RegisterCommonHostedServices(this IServiceCollection services, string microserviceName)
        {
            services.ConfigureSwagger(microserviceName);
        }

        private static void RegisterCommonApiServices(this IServiceCollection services, string microserviceName,
            Action<IMvcCoreBuilder> mvcCoreBuilderAction = null,
            Action<IMvcBuilder> mvcBuilderAction = null)
        {
            var mvcCoreBuilder = services
                .AddMvcCore()
                .AddApiExplorer();

            mvcCoreBuilderAction?.Invoke(mvcCoreBuilder);

            var mvcBuilder = services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy(),
                    };
                });

            mvcBuilderAction?.Invoke(mvcBuilder);
        }

        private static void RegisterCommonMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<APIMiddleware>();
        }
    }
}

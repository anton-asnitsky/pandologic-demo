using AutoMapper;
using Microsoft.Extensions.Configuration;
using Commons.Extensions.Startup;
using Commons.Validation.Interfaces;
using GraphData.API.Communication.Request;
using GraphData.API.Validators;
using GraphData.Data.Interfaces;
using GraphData.Data.Models;
using GraphData.Data.Stores;
using GraphData.Services;
using GraphData.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphData.API
{
    public static class StartupExtensions
    {
        public static void RegisterStartupServices(
            this IServiceCollection services,
            IConfiguration configuration,
            string microserviceName)
        {
            CommonStartupExtensions.RegisterCommonExtensions(services, configuration, microserviceName);

            services.RegisterMappings(configuration);
            services.RegisterDataStores(configuration);
            services.RegisterServices(configuration);
            services.RegisterValidators(configuration);
            services.RegisterHostedServices(configuration);
        }

        public static void RegisterStartupServices(
            this IApplicationBuilder app,
            IWebHostEnvironment env,
            IConfiguration configuration,
            string microserviceName)
        {
            CommonStartupExtensions.RegisterCommonExtensions(app, env, configuration, microserviceName);
        }


        public static void RegisterValidators(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRequestValidator, CompositeRequestValidator>();
        }

        public static void RegisterHostedServices(this IServiceCollection services, IConfiguration configuration)
        {
        }

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPredictionsService, PredictionsService>();
            services.AddTransient<IGraphDataService, GraphDataService>();
        }

        public static void RegisterDataStores(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGraphDataQuery, GraohDataQuery>();
        }

        

        public static void RegisterMappings(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GetGraphDataRequest, QueryFilter>()
                ;
            });

            services.AddSingleton(config.CreateMapper());
        }
    }
}
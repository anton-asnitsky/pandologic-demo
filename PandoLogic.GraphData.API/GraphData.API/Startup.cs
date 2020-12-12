using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commons.Extensions.Startup;

namespace GraphData.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public static string MicroserviceName => "GraphData.API";

        public Startup(IConfiguration configuration) { Configuration = configuration; }

        public void ConfigureServices(IServiceCollection services) =>
            services.RegisterStartupServices(Configuration, MicroserviceName);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app.RegisterStartupServices(env, Configuration, MicroserviceName);
    }
}

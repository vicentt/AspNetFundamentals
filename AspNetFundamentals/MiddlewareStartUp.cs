using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AspNetFundamentals.Services;
using AspNetFundamentals.Abstrations;
using Newtonsoft.Json;

namespace AspNetFundamentals
{
    public class MiddlewareStartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddVicenFancyFramework();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseVicen();
        }
    }

    public class MyTimingMiddleware 
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<ApiConfiguration> logger;

        //public MyTimingMiddleware(RequestDelegate next, ILogger<ApiConfiguration> logger)
        //{
        //    this.next = next;
        //    this.logger = logger;
        //}

        public MyTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }



        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Soy el primer middleware");
            var stopWatch = Stopwatch.StartNew();
            await _next(context);
            stopWatch.Stop();
            //this.logger.LogDebug("Request took " + stopWatch.ElapsedMilliseconds.ToString());
            Console.WriteLine("Request took " + stopWatch.ElapsedMilliseconds.ToString());
        }
       
    }
}

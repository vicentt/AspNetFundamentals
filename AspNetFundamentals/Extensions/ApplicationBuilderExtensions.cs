using System;
using AspNetFundamentals;
using AspNetFundamentals.Abstrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
       public static IApplicationBuilder UseVicen(this IApplicationBuilder app)
        {
            app.UseMiddleware<MyTimingMiddleware>();

            app.Use(async (context, next) =>
           {
               Console.WriteLine("Entering Middleware1");
               context.Response.Headers.Add("Middleware1Header", "value1");
               await next.Invoke();
               Console.WriteLine("Exiting Middleware1");

           });
            app.Map("/vicen", appBuilder =>
            {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Branch de vicen"); 
                });
            });

            app.MapWhen(c => c.Request.Headers.ContainsKey("MiHeader"),  appBuilder => {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Branch de mapwen");
                });
                
            });

            app.Run(async context =>
            {
                var logroñoService = context.RequestServices.GetService<ILogroñoGuide>();
                await context.Response.WriteAsync(JsonConvert.SerializeObject(logroñoService.GetPlacesOfInterest()));
            });

            return app;

        }
    }
}

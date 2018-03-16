using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using AspNetFundamentals.Abstrations;
using AspNetFundamentals.Services;
//using AspNetFundamentals.Infractructure.Formatters;
using Microsoft.AspNetCore.Mvc.Formatters;
using AspNetFundamentals.Api.Cities.Request;
//using AspNetFundamentals.Infractructure.Conventions;
using AspNetFundamentals.Infractructure.Filters;
//using AspNetFundamentals.Infractructure.FormatFilters;
using Microsoft.ApplicationInsights.Extensibility;
using AspNetFundamentals.Infractructure.Conventions;

namespace AspNetFundamentals
{
    public class ApiConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddJsonFormatters()
                .AddMvcOptions(options =>
                {
                    options.Conventions.Add(new RequiresHeaderApplicationConvention());
                    options.Filters.Add(typeof(ValidModelStateFilter));
                    //options.OutputFormatters.Add(new SiteofInterestsOutputFormatter());
                    //options.FormatterMappings.SetMediaTypeMappingForFormat("logronosites", "text/logronosites");
                })
                .AddFormatterMappings();
                //.AddFluentValidation(config =>
                //{
                //    config.RegisterValidatorsFromAssemblyContaining<ApiConfiguration>();
                //});

            services.AddSingleton<ILogroñoGuide, LogroñoGuide>();
            //services.Add(ServiceDescriptor.Singleton<FormatFilter, NonRequiredFormatFilter>());

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            TelemetryConfiguration.Active.DisableTelemetry = true;

            app.UseMvc();
        }
    }
}

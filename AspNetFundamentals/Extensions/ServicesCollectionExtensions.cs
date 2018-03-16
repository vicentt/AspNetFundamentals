using System;
using AspNetFundamentals.Abstrations;
using AspNetFundamentals.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddVicenFancyFramework(this IServiceCollection services)
        {
            services.AddSingleton<ILogroñoGuide, LogroñoGuide>();
            services.AddMvcCore();
            return services;

        }
    }
}

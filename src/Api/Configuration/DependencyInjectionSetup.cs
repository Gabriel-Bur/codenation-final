using Infra.CrossCutting.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Configuration
{
    public static class DependencyInjectionSetup
    {

        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            NativeInjector.RegisterServices(services);
        }
    }
}

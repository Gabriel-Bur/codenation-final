using Application.Interfaces;
using Application.Services;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IOC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IErrorAppService, ErrorAppService>();

            // Data - Context
            services.AddScoped<DatabaseContext>();

            // Data - Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IErrorRepository, ErrorRepository>();
            services.AddScoped<IErrorFileRepository, ErrorFileRepository>();
        }
    }
}

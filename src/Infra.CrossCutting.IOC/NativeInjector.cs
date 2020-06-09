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

            #region Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IErrorRepository, ErrorRepository>();
            #endregion


            #region Services
            services.AddScoped<IUserAppService, UserAppService>();
            #endregion

            // Data - Infra
            services.AddScoped<DatabaseContext>();
        }
    }
}

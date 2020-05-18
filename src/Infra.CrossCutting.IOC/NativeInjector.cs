using Application.Services;
using Domain.Core.Interfaces.Repository;
using Domain.Core.Interfaces.Service;
using Infra.Data.Repository.Repositories;
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
        }
    }
}

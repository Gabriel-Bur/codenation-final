using Application.Services;
using Autofac;
using Domain.Core.Interfaces.Repository;
using Domain.Core.Interfaces.Service;
using Infra.Data.Repository.Repositories;

namespace Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void LoadConfiguration(ContainerBuilder builder)
        {
            #region Repository
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ErrorRepository>().As<IErrorRepository>();
            #endregion


            #region Services
            builder.RegisterType<UserService>().As<IUserService>();
            #endregion
        }
    }
}

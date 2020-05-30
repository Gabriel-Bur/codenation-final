using Application.Interfaces;
using Application.ViewModels;
using Domain.Core.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> IsValidLogin(UserLoginViewModel userLoginViewModel)
        {
            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

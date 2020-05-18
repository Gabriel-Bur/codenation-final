using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Domain.Core.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            _userRepository = _userRepository;
        }



        public Task<bool> IsValidUser(object userDTO)
        {
            //TODO check if authentication is correct
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

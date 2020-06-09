using Application.Interfaces;
using Application.ViewModels.Request;
using Application.ViewModels.Response;
using AutoMapper;
using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper,
            IUserRepository userRepository)
        {
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));

            _userRepository = userRepository ?? 
                throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> IsValidLogin(UserLoginRequest userLoginRequest)
        {
            var user = await _userRepository.FindByEmail(userLoginRequest.Email);

            if (user != null && user.Password == userLoginRequest.Password)
            {
                return true;
            }
            return false;
        }

        public async Task<UserSingUpResponse> CreateLogin(UserSingUpRequest userSingUpRequest)
        {
            var user = await _userRepository.Insert(_mapper.Map<User>(userSingUpRequest));
            return _mapper.Map<UserSingUpResponse>(user);
        }

        public void Dispose()
        {
            _userRepository.Dispose();
        }

    }
}

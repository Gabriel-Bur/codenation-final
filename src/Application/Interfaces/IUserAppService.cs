using Application.ViewModels;
using Application.ViewModels.Request;
using Application.ViewModels.Response;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<bool> IsValidLogin(UserLoginRequest userLoginViewModel);
        Task<UserSingUpResponse> CreateLogin(UserSingUpRequest userSingUpViewModel);
    }
}

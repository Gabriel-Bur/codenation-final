using Application.ViewModels.Request;
using Application.ViewModels.Response;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserAppService
    {
        Task<bool> IsValidLogin(UserLoginRequest userLoginViewModel);
        Task<bool> IsEmailExist(string email);
        Task<UserSingUpResponse> CreateLogin(UserSingUpRequest userSingUpViewModel);

    }
}

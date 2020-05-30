using Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<bool> IsValidLogin(UserLoginViewModel userDTO);
    }
}

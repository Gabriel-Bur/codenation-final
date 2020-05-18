using System;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Service
{
    public interface IUserAppService : IDisposable
    {
        Task<bool> IsValidUser(object userDTO);
    }
}

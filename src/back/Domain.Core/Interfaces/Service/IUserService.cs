using Domain.Core.Entity;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Service
{
    public interface IUserService : IBaseService<User>
    {
        Task<bool> IsValidUser(object userDTO);
    }
}

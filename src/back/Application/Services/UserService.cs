using Domain.Core.Entity;
using Domain.Core.Interfaces.Service;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public Task<bool> IsValidUser(object userDTO)
        {
            //TODO check if authentication is correct
            throw new System.NotImplementedException();
        }
    }
}

using Domain.Core.Entity;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByEmail(string email);
    }
}

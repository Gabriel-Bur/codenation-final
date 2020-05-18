using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;

namespace Infra.Data.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }




    }
}

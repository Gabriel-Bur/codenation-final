using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected const string TABLE_NAME = "User";

        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<User> FindByEmail(string email)
        {
            var result = _dbSet
                .Where(x => x.Email == email)
                .ToList();

            return result.FirstOrDefault();
        }
    }
}

using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<User> FindByEmail(string email)
        {
            var result = await _dbSet
                .Where(x => x.Email == email)
                .ToListAsync();

            return result.FirstOrDefault();
        }
    }
}

﻿using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        protected const string TABLE_NAME = "User";

        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<User> FindByEmail(string email)
        {
            string query =
                $"SELECT * FROM {TABLE_NAME} " +
                $"WHERE Email = {0}";

            var result = await ExecuteQuery(query, email);

            return result.FirstOrDefault();
        }

    }
}

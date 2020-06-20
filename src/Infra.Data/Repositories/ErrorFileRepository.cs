using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ErrorRepository : Repository<Error>, IErrorRepository
    {
        public ErrorRepository(DatabaseContext context) : base(context)
        {
        }
    }
}

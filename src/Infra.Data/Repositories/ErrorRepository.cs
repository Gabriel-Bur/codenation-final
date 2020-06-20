using Domain.Core.Interfaces.Repository;
using Domain.Entity;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ErrorFileRepository : Repository<ErrorFile>, IErrorFileRepository
    {
        public ErrorFileRepository(DatabaseContext context) : base(context)
        {
        }
    }
}

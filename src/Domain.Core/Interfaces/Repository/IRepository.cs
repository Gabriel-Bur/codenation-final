using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> SelectAll();
        Task<T> SelectById(Guid id);
        Task<T> Insert(T obj);
        Task InsertRange(IEnumerable<T> obj);
        Task Update(Guid id, T obj);
        Task Delete(Guid id);
    }
}

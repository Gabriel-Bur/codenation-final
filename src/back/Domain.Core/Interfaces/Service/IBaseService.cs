using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Interfaces.Service
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> SelectAll();
        Task<T> SelectById(Guid id);
        Task<T> Insert(T obj);
        Task Update(Guid id, T obj);
        Task Delete(Guid id);
    }
}

using Domain.Core;
using Domain.Core.Interfaces.Service;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BaseService<T> : IDisposable, IBaseService<T> where T : BaseEntity
    {
        private BaseRepository<T> _baseRepository = new BaseRepository<T>();

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await _baseRepository.SelectAll();
        }

        public async Task<T> SelectById(Guid id)
        {
            return await _baseRepository.SelectById(id);
        }

        public async Task<T> Insert(T obj)
        {
            return await _baseRepository.Insert(obj);
        }

        public async Task Update(Guid id, T obj)
        {
            await _baseRepository.Update(id, obj);
        }

        public async Task Delete(Guid id)
        {
            await _baseRepository.Delete(id);
        }

        public virtual void Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}

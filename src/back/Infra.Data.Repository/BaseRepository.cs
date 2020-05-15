using Domain.Core;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        public virtual async Task<IEnumerable<T>> SelectAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> SelectById(Guid id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task<T> Insert(T obj)
        {
            try
            {
                obj.CreationDataTime = DateTime.UtcNow;
                await _context.Set<T>().AddAsync(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task Update(Guid id, T obj)
        {
            try
            {
                if (await SelectById(id) != null)
                {
                    _context.Entry(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task Delete(Guid id)
        {
            try
            {
                T obj = await SelectById(id);
                if(obj != null)
                {
                    obj.DeletionDateTime = DateTime.UtcNow;
                    _context.Entry(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual void Dispose()
        {
            _context.Dispose();
        }

    }
}

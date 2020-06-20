using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly DatabaseContext context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            this._dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> SelectAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
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
                return await _dbSet.FindAsync(id);
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
                await _dbSet.AddAsync(obj);
                await SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual async Task InsertRange(IEnumerable<T> obj)
        {
            try
            {
                _dbSet.AddRange(obj);
                await SaveChangesAsync();
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
                    _dbSet.Update(obj);
                    await SaveChangesAsync();
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
                    _dbSet.Remove(obj);
                    await SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}

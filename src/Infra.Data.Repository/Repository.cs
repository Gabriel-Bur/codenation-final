using Domain.Core;
using Domain.Core.Entity;
using Domain.Core.Interfaces.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected readonly DatabaseContext context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext context)
        {
            this.context = context;
            _dbSet = context.Set<T>();
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
                SaveChangesAsync();

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
                    _dbSet.Update(obj);
                    SaveChangesAsync();
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
                    SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private async void SaveChangesAsync()
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TruckApp.Data.Data;
using TruckApp.Domain.Entities;
using TruckApp.Domain.Repositories;

namespace TruckApp.Data.Repositories
{
    public class Repository<T>: IRepository<T> where T: Entity
    {
        private TruckContext _truckContext;
        private DbSet<T> Query;

        public Repository(TruckContext truckContext)
        {
            _truckContext = truckContext;
            Query = _truckContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            Query.Add(entity);
            await _truckContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await Query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await Query.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            Query.Update(entity);
            await _truckContext.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            var entity = await GetById(id);
            Query.Remove(entity);
            await _truckContext.SaveChangesAsync();
        }
    }
}
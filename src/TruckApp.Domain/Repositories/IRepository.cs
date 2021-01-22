using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckApp.Domain.Entities;

namespace TruckApp.Domain.Repositories
{
    public interface IRepository<T> where T: Entity
    {
        Task<Guid> Add(T entity);
        Task<IEnumerable<T>> ListAll();
        Task<T> GetById(Guid id);
        Task Update(T entity);
        Task Remove(Guid id);
    }
}
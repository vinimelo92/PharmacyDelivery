using System;
using PharmacyDelivery.Models;

namespace PharmacyDelivery.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(string id);

        Task<T> GetAsync(string id);

        Task<List<T>> ListAsync();
    }
}
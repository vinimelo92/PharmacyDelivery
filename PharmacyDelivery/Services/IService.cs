using PharmacyDelivery.Models;

namespace PharmacyDelivery.Services
{
    public interface IService<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(string id);
        Task<T> GetAsync(string id);
        Task<List<T>> ListAsync();
    }
}

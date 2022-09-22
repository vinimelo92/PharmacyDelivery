using PharmacyDelivery.Models;
using PharmacyDelivery.Repositories;

namespace PharmacyDelivery.Services
{
    public class Service<T> : IService<T> where T : Entity
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> GetAsync(string id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<T> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<List<T>> ListAsync()
        {
            return await _repository.ListAsync();
        }
    }
}

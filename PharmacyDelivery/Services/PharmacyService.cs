using PharmacyDelivery.Models;
using PharmacyDelivery.Repositories;

namespace PharmacyDelivery.Services
{
    public class PharmacyService : Service<Pharmacy>, IPharmacyService
    {
        private readonly IRepository<Pharmacy> _repository;

        public PharmacyService(IRepository<Pharmacy> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<Pharmacy> CreatePharmacy(string name, string imagePath, string zipCode)
        {
            Pharmacy pharmacy = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                ImagePath = imagePath,
                ZipCode = zipCode,
                CreatedAt = DateTime.UtcNow
            };

            return await AddAsync(pharmacy);
        }

        public async Task<Pharmacy> GetPharmacy(string id)
        {
            return await GetAsync(id);
        }

        public async Task<List<Pharmacy>> GetPharmacies()
        {
            return await ListAsync();
        }

        public async Task<Pharmacy> DeletePharmacy(string id)
        {
            return await DeleteAsync(id);
        }

        public async Task<Pharmacy> UpdatePharmacy(string id, string name, string imagePath, string zipCode)
        {
            Pharmacy pharmacy = new()
            {
                Id = id,
                Name = name,
                ImagePath = imagePath,
                ZipCode = zipCode
            };

            return await UpdateAsync(pharmacy);
        }
    }
}

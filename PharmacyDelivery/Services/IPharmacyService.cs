using Microsoft.AspNetCore.Mvc;
using PharmacyDelivery.Models;

namespace PharmacyDelivery.Services
{
    public interface IPharmacyService
    {
        Task<Pharmacy> CreatePharmacy(string name, string imagePath, string zipCode);

        Task<Pharmacy> GetPharmacy(string id);

        Task<List<Pharmacy>> GetPharmacies();

        Task<Pharmacy> DeletePharmacy(string id);

        Task<Pharmacy> UpdatePharmacy(string id, string name, string imagePath, string zipCode);
    }
}

using Microsoft.EntityFrameworkCore;
using PharmacyDelivery.Models;

namespace PharmacyDelivery.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Pharmacy> Pharmacies { get; set; }
    }
}
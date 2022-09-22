using System.ComponentModel.DataAnnotations;

namespace PharmacyDelivery.Models
{
    public interface IEntity
    {
        [Key]
        string Id { get; set; }
    }
}
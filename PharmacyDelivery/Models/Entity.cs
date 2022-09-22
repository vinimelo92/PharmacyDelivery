using System.ComponentModel.DataAnnotations;

namespace PharmacyDelivery.Models
{
    public class Entity: IEntity
    {
        [Key]
        public string Id { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDelivery.Models
{
    [Table("Pharmacy")]
    public class Pharmacy : Entity
    {
        [StringLength(255)]
        public string Name { get; set; }
        
        [StringLength(255)]
        public string ImagePath { get; set; }

        [StringLength(255)]
        public string ZipCode { get; set; }
    }
}

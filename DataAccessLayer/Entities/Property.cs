using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Property : BaseEntity<Guid>
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public Guid AddressID { get; set; }
        public virtual Address? Address { get; set; }

        [Required]
        public string Type { get; set; }  // e.g., Apartment, House, Commercial

        [Required, Range(0, double.MaxValue)]
        public decimal Area { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public bool IsOccupied{ get; set; }

        // Navigation property
        public virtual ICollection<Contract>? Contracts { get; set; }
    }
}

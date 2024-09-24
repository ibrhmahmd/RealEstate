using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOModels
{
    public class PropertyDTO : BaseEntity<Guid>
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public Guid AddressID { get; set; }

        [Required]
        public string Type { get; set; }  // e.g., Apartment, House, Commercial

        [Required, Range(0, double.MaxValue)]
        public decimal Area { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public bool IsOccupied { get; set; }

        // Navigation property
        public virtual ICollection<Contract>? Contracts { get; set; }
    }
}

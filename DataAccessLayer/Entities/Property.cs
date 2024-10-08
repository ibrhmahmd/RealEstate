using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DataAccessLayer.Entities
{
    public class Property : BaseEntity<Guid>
    {
        [Required, StringLength(100)]
        public string? Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string? PropertyPictureUrl { get; set; }

        [NotMapped]
        public IFormFile? PropertyPicture { get; set; }

        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
   

        [MaxLength(50)]
        public string Location { get; set; }
        [Required]
        public string Type { get; set; }  // e.g., Apartment, House, Commercial


        [Required, Range(0, double.MaxValue)]
        public decimal Area { get; set; }

        [Required, Range(0, 20)]
        public int Rooms { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public bool IsOccupied { get; set; }

        public int? Longitude { get; set; }
        public int? Latitude { get; set; }

        [Required]
        public bool IsFUrnished { get; set; }

        public PropertStatus? Status { get; set; }

        // Navigation property
        public virtual ICollection<Contract>? Contracts { get; set; }
    }


    public enum PropertStatus
    {
        Lease,
        Ownership,
        Rent
    }
}
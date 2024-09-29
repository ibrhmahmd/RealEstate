﻿using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.DTOModels
{
    public class PropertyDTO : BaseEntity<Guid>
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        public string? PropertyPictureUrl { get; set; }

        [NotMapped]
        public IFormFile? PropertyPicture { get; set; }
        [Required]
        public string Type { get; set; }  // e.g., Apartment, House, Commercial

        [Required, Range(0, double.MaxValue)]
        public decimal Area { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [MaxLength(50)]
        public string? Location { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public bool IsOccupied { get; set; }

        // Navigation property
        public virtual ICollection<Contract>? Contracts { get; set; }
    }
}
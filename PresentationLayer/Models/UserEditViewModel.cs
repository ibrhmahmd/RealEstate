using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationLayer.Models
{
    public class UserEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public IFormFile? UserPicture { get; set; }
        public string? UserPictureUrl { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
    
    }
}
using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.DTOModels
{
    public class UserDTO : IdentityUser<Guid>
    {
        public required string Email { get; set; }
        public required string Password { get; set; } // Consider marking this as [NotMapped] if using EF Core
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}


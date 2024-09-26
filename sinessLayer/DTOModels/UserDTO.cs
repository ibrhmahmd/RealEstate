using Microsoft.AspNetCore.Identity;

namespace BusinessLayer.DTOModels
{
    public class UserDTO : IdentityUser<Guid>
    {
        public string? Role { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
    }
}

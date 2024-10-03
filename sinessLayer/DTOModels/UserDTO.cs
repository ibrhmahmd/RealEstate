using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.DTOModels
{
    public class UserDTO : IdentityUser<Guid>
    {
		public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public string Role { get; set; } // Add this property if it's not present

        public bool? IsVerified { get; set; } = false;
        public virtual ICollection<Contract>? Contracts { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}

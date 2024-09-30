using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer.DTOModels
{
    public class UserDTO : IdentityUser<Guid>
    {
		public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
  
    }
}

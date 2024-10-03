using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User : IdentityUser<Guid>
    {
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        public string Role { get; set; } // Add this property if it's not present

        public bool? IsVerified { get; set; }

        public virtual ICollection<Contract>? Contracts { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}

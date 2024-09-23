﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        public string Role { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Address: BaseEntity<Guid>
    {
        [StringLength(50)]
        public string City{ get; set; }
        [StringLength(50)]
        public string State{ get; set; }

        // Navigation 
        public IEnumerable<Property>? Properties { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Address
    {
        public Guid AddressID { get; set; }

        public string City{ get; set; }
        
        public string State{ get; set; }

        // Navigation 
        public IEnumerable<Property> Properties { get; set; }
    }
}

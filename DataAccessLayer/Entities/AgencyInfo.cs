using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class AgencyInfo : BaseEntity<Guid>
    {
        [Required, StringLength(20)]
        public string Name{ get; set; }

        [Required, StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required,StringLength(20)]
        public string Email{ get; set; }

        [Required, StringLength(20)]
        public string Address { get; set; }

        [Required, StringLength(20)]
        public string City { get; set; }

        public int MyProperty { get; set; }

    }
}

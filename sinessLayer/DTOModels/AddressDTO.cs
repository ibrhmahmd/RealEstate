using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOModels
{
    public class AddressDTO : BaseEntity<Guid>
    {

        [StringLength(50)]
        public string City { get; set; }
        [StringLength(50)]
        public string State { get; set; }

    }
}

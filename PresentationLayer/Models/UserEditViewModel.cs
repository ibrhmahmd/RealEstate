using System.ComponentModel.DataAnnotations.Schema;

namespace PresentationLayer.Models
{
    public class UserEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
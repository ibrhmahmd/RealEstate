namespace PresentationLayer.Models
{
    public class UserEditViewModel
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IFormFile UserPicture { get; set; }
        public string UserPictureURL { get; set; }
        public string PhoneNumber { get; set; }
    }
}

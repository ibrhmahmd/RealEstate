using BusinessLayer.DTOModels;

namespace PresentationLayer.Models
{
    public class PropertyListViewModel
    {
        public List<PropertyDTO> Properties { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}

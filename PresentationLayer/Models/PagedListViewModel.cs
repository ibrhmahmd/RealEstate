using BusinessLayer.DTOModels;

namespace PresentationLayer.Models
{
    public class PagedListViewModel<T>
    {
        public Guid UserId { get; set; }
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
    }
}

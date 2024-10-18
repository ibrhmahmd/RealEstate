using BusinessLayer.DTOModels;
using DataAccessLayer.GenericRepository;

namespace BusinessLayer.Services
{
    public interface IPropertyService
    {
        Task<PropertyDTO> CreatePropertyAsync(PropertyDTO propertyDto);
        Task<PagedResult<PropertyDTO>> GetAllPropertiesAsync(int pageNumber, int pageSize);
        Task<IQueryable<PropertyDTO>> GetAllPropertiesIncludingDeletedAsync();
        Task<PagedResult<PropertyDTO>> GetAvailblePropertiesAsync(int pageNumber, int pageSize);
        Task<PropertyDTO> GetPropertyByIdAsync(Guid Id);
        Task HardDeletePropertyAsync(Guid Id);
        Task PropertyOccupiedAsync(Guid Contractid, Guid UserId);
        Task RestorePropertyAsync(Guid Id);
        Task SoftDeletePropertyAsync(Guid Id);
        Task<PropertyDTO> UpdatePropertyAsync(PropertyDTO propertyDto);
    }
}
using BusinessLayer.DTOModels;
using DataAccessLayer.GenericRepository;

namespace BusinessLayer.Services
{
    public interface IDeveloperCompanyService
    {
        Task<DeveloperCompanyDTO> CreateDeveloperCompanyAsync(DeveloperCompanyDTO companyDto);
        Task<List<DeveloperCompanyDTO>> GetAllDeveloperCompaniesAsync();
        Task<PagedResult<DeveloperCompanyDTO>> GetAllDeveloperCompaniesAsync(int pageNumber, int pageSize);
        Task<DeveloperCompanyDTO> GetDeveloperCompanyByIdAsync(Guid id);
        Task RestoreDeveloperCompanyAsync(Guid id);
        Task SoftDeleteDeveloperCompanyAsync(Guid id);
        Task<DeveloperCompanyDTO> UpdateDeveloperCompanyAsync(DeveloperCompanyDTO companyDto);
    }
}
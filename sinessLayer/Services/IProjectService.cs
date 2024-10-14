using BusinessLayer.DTOModels;
using DataAccessLayer.GenericRepository;

namespace BusinessLayer.Services
{
    public interface IProjectService
    {
        Task<ProjectDTO> CreateProjectAsync(ProjectDTO projectDto);
        Task<IQueryable<ProjectDTO>> GetAllProjectsAsync();
        Task<PagedResult<ProjectDTO>> GetAllProjectsAsync(int pageNumber, int pageSize);
        Task<ProjectDTO> GetProjectByIdAsync(Guid id);
        Task RestoreProjectAsync(Guid id);
        Task SoftDeleteProjectAsync(Guid id);
        Task<ProjectDTO> UpdateProjectAsync(ProjectDTO projectDto);
    }
}
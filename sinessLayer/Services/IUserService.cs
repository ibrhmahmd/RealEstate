using BusinessLayer.DTOModels;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using System.Security.Claims;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<User> CreateUserAsync(User user);
        Task<PagedResult<UserDTO>> GetAllUsersAsync(int pageNumber, int pageSize);
        Task<List<User>> GetAllUsersIncludingDeletedAsync();
        User GetCurrentUser(ClaimsPrincipal userPrincipal);
        Task<(List<PropertyDTO> properties, int totalItems)> GetLeasedPropertiesAsync(Guid userId, int pageNumber, int pageSize);
        Task<(List<PropertyDTO> properties, int totalItems)> GetOwnedPropertiesAsync(Guid userId, int pageNumber, int pageSize);
        Task<User> GetUserByIdAsync(Guid id);
        Task<(List<ContractDTO> Contracts, int TotalItems)> GetUserContractsAsync(Guid userId, int pageNumber, int pageSize);
        Task<(List<PropertyDTO> properties, int totalItems)> GetUserPropertiesAsync(Guid userId, int pageNumber, int pageSize);
        Task<List<string>> GetUserRolesAsync(Guid userId);
        Task HardDeleteUserAsync(Guid id);
        Task<bool> RegisterUserAsync(string email, string password, string role);
        Task RestoreUserAsync(Guid id);
        Task SoftDeleteUserAsync(Guid id);
        Task<User> UpdateUserAsync(User user);
        Task<bool> VerifyUser(Guid id);
    }
}
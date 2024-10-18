using BusinessLayer.DTOModels;
using DataAccessLayer.GenericRepository;

namespace BusinessLayer.Services
{
    public interface IContractService
    {
        Task AcceptContract(Guid Id);
        Task<PagedResult<ContractDTO>> AcceptedContractsAsync(int pageNumber, int pageSize);
        Task ArchiveContract(Guid id);
        Task<ContractDTO> CreateContractAsync(ContractDTO contractDto);
        Task<PagedResult<ContractDTO>> GetAllContractsAsync(int pageNumber, int pageSize);
        Task<IQueryable<ContractDTO>> GetAllContractsIncludingDeletedAsync();
        Task<PagedResult<ContractDTO>> GetArchivedContractsAsync(int pageNumber, int pageSize);
        Task<ContractDTO> GetContractByIdAsync(Guid id);
        Task HardDeleteContractAsync(Guid id);
        Task<ContractDTO> ProcessContractAsync(Guid propertyId);
        Task RestoreContractAsync(Guid id);
        Task SoftDeleteContractAsync(Guid id);
        Task TerminateAsync(Guid id);
        Task<PagedResult<ContractDTO>> TerminatedContractsAsync(int pageNumber, int pageSize);
        Task UnArchiveContract(Guid id);
        Task<ContractDTO> UpdateContractAsync(ContractDTO contractDto);
    }
}
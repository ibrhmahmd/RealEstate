using BusinessLayer.DTOModels;
using DataAccessLayer.GenericRepository;

namespace BusinessLayer.Services
{
    public interface IPaymentService
    {
        Task<PaymentDTO> CreatePaymentAsync(PaymentDTO paymentDto);
        Task<List<PaymentDTO>> CreatePaymentsFromContractAsync(ContractDTO contractDto);
        Task<List<PaymentDTO>> GetAllPaymentsAsync();
        Task<PagedResult<PaymentDTO>> GetAllPaymentsAsync(int pageNumber, int pageSize);
        Task<IQueryable<PaymentDTO>> GetAllPaymentsIncludingDeletedAsync();
        Task<PaymentDTO> GetPaymenttByIdAsync(Guid id);
        Task HardDeletePaymentAsync(Guid id);
        Task RestorePaymentAsync(Guid id);
        Task SoftDeletePaymentAsync(Guid id);
        Task<PaymentDTO> UpdatePaymentAsync(PaymentDTO paymentDto);
    }
}
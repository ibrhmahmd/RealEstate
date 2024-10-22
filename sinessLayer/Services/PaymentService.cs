using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using DataAccessLayer.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get all payments

        public async Task<List<PaymentDTO>> GetAllPaymentsAsync()
        {
            var payments = await _unitOfWork.PaymentsRepository.GetAllAsync(1, 5);
            return _mapper.Map<List<PaymentDTO>>(payments);
        }

        public async Task<PagedResult<PaymentDTO>> GetAllPaymentsAsync(int pageNumber, int pageSize)
        {
            var paymentsPaged = await _unitOfWork.PaymentsRepository.GetAllPagedAsync(pageNumber, pageSize);

            var PaymentDTOs = paymentsPaged.Items.Select(payment => new PaymentDTO
            {
                Id = payment.Id,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                ContractId = payment.ContractId,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,


            }).ToList();
            return new PagedResult<PaymentDTO>
            {
                Items = PaymentDTOs,
                CurrentPage = paymentsPaged.CurrentPage,
                PageSize = paymentsPaged.PageSize,
                TotalRecords = paymentsPaged.TotalRecords
            };
        }
        public async Task<PagedResult<PaymentDTO>> GetGroupedPaymentsByContractAsync(int pageNumber, int pageSize)
        {
            var paymentsPaged = await _unitOfWork.PaymentsRepository.GetAllPagedAsync(pageNumber, pageSize);

            var PaymentDTOs = paymentsPaged.Items.Select(payment => new PaymentDTO
            {
                Id = payment.Id,
                PaymentDate = payment.PaymentDate,
                Amount = payment.Amount,
                ContractId = payment.ContractId,
                PaymentMethod = payment.PaymentMethod,
                Status = payment.Status,


            }).ToList();
            return new PagedResult<PaymentDTO>
            {
                Items = PaymentDTOs,
                CurrentPage = paymentsPaged.CurrentPage,
                PageSize = paymentsPaged.PageSize,
                TotalRecords = paymentsPaged.TotalRecords
            };
        }



        // Get all Payments including soft deleted
        public async Task<IQueryable<PaymentDTO>> GetAllPaymentsIncludingDeletedAsync()
        {
            var payments = await _unitOfWork.PaymentsRepository.GetAllIncludingDeletedAsync();
            return _mapper.Map<IQueryable<PaymentDTO>>(payments);
        }



        // Get payment by ID
        public async Task<PaymentDTO> GetPaymenttByIdAsync(Guid id)
        {
            var payment = await _unitOfWork.PaymentsRepository.GetByIdAsync(id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {id} not found.");
            }
            return _mapper.Map<PaymentDTO>(payment);
        }



        // Create a new payment
        public async Task<PaymentDTO> CreatePaymentAsync(PaymentDTO paymentDto)
        {
            // payment AutoMapper to map PaymentDTO to Contract entity
            var payment = _mapper.Map<Payment>(paymentDto);

            await _unitOfWork.PaymentsRepository.InsertAsync(payment);
            await _unitOfWork.SaveAsync();

            // Return the mapped PaymentDTO (this might return a payment with an ID if you need it)
            return _mapper.Map<PaymentDTO>(payment);
        }



        // Update a payment
        public async Task<PaymentDTO> UpdatePaymentAsync(PaymentDTO paymentDto)
        {
            var existingPayment = await _unitOfWork.PaymentsRepository.GetByIdAsync(paymentDto.Id);
            if (existingPayment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {paymentDto.Id} not found.");
            }

            // Payment AutoMapper to update the existing Payment entity
            _mapper.Map(paymentDto, existingPayment);

            await _unitOfWork.PaymentsRepository.UpdateAsync(existingPayment);
            await _unitOfWork.SaveAsync();

            // Return the mapped PaymentDTO
            return _mapper.Map<PaymentDTO>(existingPayment);
        }




        // Soft delete a payment
        public async Task SoftDeletePaymentAsync(Guid id)
        {
            var payment = await _unitOfWork.PaymentsRepository.GetByIdAsync(id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {id} not found.");
            }

            await _unitOfWork.PaymentsRepository.SoftDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }




        // Hard delete a payment
        public async Task HardDeletePaymentAsync(Guid id)
        {
            var payment = await _unitOfWork.PaymentsRepository.GetByIdAsync(id);
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {id} not found.");
            }

            await _unitOfWork.PaymentsRepository.HardDeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }



        // Restore a soft deleted payment
        public async Task RestorePaymentAsync(Guid id)
        {
            var payment = await _unitOfWork.PaymentsRepository.GetByIdAsync(id); // Ensure this gets the payment entity
            if (payment == null)
            {
                throw new KeyNotFoundException($"Payment with ID {id} not found.");
            }

            if (!payment.IsDeleted) // Accessing IsDeleted from the Payment entity
            {
                throw new InvalidOperationException($"Payment with ID {id} is not deleted and cannot be restored.");
            }

            await _unitOfWork.PaymentsRepository.RestoreSoftDeletedAsync(id);
            await _unitOfWork.SaveAsync();
        }




        public async Task<List<PaymentDTO>> CreatePaymentsFromContractAsync(ContractDTO contractDto)
        {
            List<PaymentDTO> payments = new List<PaymentDTO>();

            // Initial Payment
            if (contractDto.InitialPayment.HasValue)
            {
                payments.Add(new PaymentDTO
                {
                    Id = Guid.NewGuid(),
                    Occupantname = contractDto.Occupantname,
                    PropertyName = contractDto.PropertyName,
                    ContractId = contractDto.Id,
                    PaymentDate = contractDto.StartDate,
                    Amount = contractDto.InitialPayment.Value,
                    Status = PaymentStatus.Pending,
                    PaymentMethod = "Initial Payment",
                    ReferenceNumber = Guid.NewGuid().ToString(),
                    LateFee = contractDto.RecurringPaymentAmount * 12 / 100,
                });
            }



            // Recurring Payments
            if (contractDto.RecurringPaymentAmount.HasValue && contractDto.RecurringPaymentFrequency != null)
            {
                DateTime nextPaymentDate = contractDto.StartDate;
                int totalPayments = CalculateTotalPayments(contractDto.StartDate, contractDto.EndDate, contractDto.RecurringPaymentFrequency);

                for (int i = 0; i < totalPayments; i++)
                {
                    payments.Add(new PaymentDTO
                    {
                        Id = Guid.NewGuid(),
                        ContractId = contractDto.Id,
                        PaymentDate = nextPaymentDate,
                        Occupantname = contractDto.Occupantname,
                        PropertyName = contractDto.PropertyName,
                        Amount = contractDto.RecurringPaymentAmount.Value,
                        Status = PaymentStatus.Pending,
                        PaymentMethod = "Recurring Payment",
                        ReferenceNumber = Guid.NewGuid().ToString(),
                        LateFee = contractDto.RecurringPaymentAmount * 12 / 100,
                    });
                    nextPaymentDate = GetNextPaymentDate(nextPaymentDate, contractDto.RecurringPaymentFrequency);
                }
            }
            foreach (PaymentDTO paymentDto in payments)
            {
                await _unitOfWork.PaymentsRepository.InsertAsync(_mapper.Map<Payment>(paymentDto));
                await _unitOfWork.SaveAsync();
            }
            return payments;
        }



        private int CalculateTotalPayments(DateTime startDate, DateTime? endDate, string frequency)
        {
            if (!endDate.HasValue || endDate < startDate)
            {
                return 0; // No payments if end date is not provided or is before start date
            }

            int totalPayments = 0;

            if (frequency == "Monthly")
            {
                totalPayments = ((endDate.Value.Year - startDate.Year) * 12) + endDate.Value.Month - startDate.Month;
            }
            else if (frequency == "Quarterly")
            {
                totalPayments = ((endDate.Value.Year - startDate.Year) * 4) + (endDate.Value.Month - startDate.Month) / 3;
            }
            else
            {
                throw new ArgumentException("Invalid frequency specified. Use 'Monthly' or 'Quarterly'.");
            }
            return totalPayments > 0 ? totalPayments : 0; // Ensure non-negative result
        }

        private DateTime GetNextPaymentDate(DateTime currentDate, string frequency)
        {
            // Check the frequency and calculate the next payment date accordingly
            if (frequency == "Monthly")
            {
                return currentDate.AddMonths(1); // Add one month for monthly payments
            }
            else if (frequency == "Quarterly")
            {
                return currentDate.AddMonths(3); // Add three months for quarterly payments
            }
            else
            {
                throw new ArgumentException("Invalid frequency specified. Use 'Monthly' or 'Quarterly'.");
            }
        }
    }
}
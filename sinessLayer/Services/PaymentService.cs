using AutoMapper;
using BusinessLayer.DTOModels;
using BusinessLayer.UnitOfWork.Interface;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	public class PaymentService
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
			var payments = await _unitOfWork.PaymentsRepository.GetAllAsync(1,5);
			return _mapper.Map<List<PaymentDTO>>(payments);
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
		public async Task<PaymentDTO> CreateContractAsync(PaymentDTO paymentDto)
		{
			// payment AutoMapper to map PaymentDTO to Contract entity
			var payment = _mapper.Map<Payment>(paymentDto);

			await _unitOfWork.PaymentsRepository.InsertAsync(payment);
			await _unitOfWork.SaveAsync();

			// Return the mapped PaymentDTO (this might return a payment with an ID if you need it)
			return _mapper.Map<PaymentDTO>(payment);
		}



		// Update a payment
		public async Task<PaymentDTO> UpdateContractAsync(PaymentDTO paymentDto)
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
		public async Task RestoreContractAsync(Guid id)
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

	}
}
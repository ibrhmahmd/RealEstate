using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.DTOModels
{
	public class ContractDTO : BaseEntity<Guid>
	{
		[Required]
		public Guid PropertyId { get; set; }

		[Required]
		public Guid OccupantId { get; set; } // Renamed UserID to TenantId

		public Guid? AgentId { get; set; } // Optional agent who reviewed the contract

		[Required]
		public Guid PaymentMethodId { get; set; } // Foreign Key for PaymentMethod


		public virtual ICollection<Payment>? Payments { get; set; } // Payments associated with the contract

		// Additional Contract Information
		[Required]
		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

        [Required, MaxLength(20)]
		public string ContractType { get; set; } // Lease, Ownership, etc.

		[Range(0, double.MaxValue)]
		public decimal? InitialPayment { get; set; } // Initial down payment or security deposit

		[Range(0, double.MaxValue)]
		public decimal? RecurringPaymentAmount { get; set; } // Monthly rent or installment amount

		[Required, MaxLength(20)]
		public string RecurringPaymentFrequency { get; set; } = "Monthly"; // Monthly, Quarterly, etc.

		[Range(0, double.MaxValue)]
		public decimal? TotalAmount { get; set; } // Total contract amount for sale or lease

		[Required]
		public bool IsConditionCheckRequired { get; set; } = false; // Pre-contract inspections

		[Required]
		public decimal LateFee { get; set; } // Late payment fee

		public bool? IsTerminated { get; set; } = false; // Indicates whether the contract is terminated

		public string? Document { get; set; } // Path to the contract document (optional)

		[Required, MaxLength(200)]
		public string PropertyLocation { get; set; } // Location of the property

		public bool IsFurnished { get; set; } = false; // Is the property furnished?

		[Range(0, 20)]
		public int Rooms { get; set; } // Number of rooms in the property
	
	}
}

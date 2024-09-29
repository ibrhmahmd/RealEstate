using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Contract : BaseEntity<Guid>
    {
        // Foreign Keys
        [Required]
        public Guid PropertyID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public Guid AgentId { get; set; } // the agent who reviewed the contract

        [Required]
        public Guid PaymentMethodId { get; set; } // Foreign Key for PaymentMethod from Payment table

        // Contract Information
        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required, MaxLength(20)]
        public string ContractType { get; set; } // Lease, Ownership

        [Range(0, double.MaxValue)]
        public decimal? InitialPayment { get; set; } // Security deposit or initial down payment 

        [Range(0, double.MaxValue)]
        public decimal? RecurringPaymentAmount { get; set; } // Monthly rent or installment amount

        [Required, MaxLength(20)]
        public string RecurringPaymentFrequency { get; set; } = "Monthly"; // Monthly, Quarterly, etc.

        [Range(0, double.MaxValue)]
        public decimal? TotalAmount { get; set; } // Total contract amount for sale or lease

        [Required]
        public bool IsConditionCheckRequired { get; set; } = false; // For pre-contract inspections

        [Required]
        public int LateFee { get; set; } // Late payment fee

        public bool IsTerminated { get; set; } = false; // Indicates whether the contract is terminated

        public string? Document { get; set; } // Path to the contract document (optional)

        // Property Details
        [Required, MaxLength(200)]
        public string PropertyLocation { get; set; } // Location of the property

        public bool IsFurnished { get; set; } = false; // Is the property furnished?

        [Range(0, 20)]
        public int Rooms { get; set; } // Number of rooms in the property

        // Navigation property for payments
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}
using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOModels
{
    public class PaymentDTO : BaseEntity<Guid>
    {
        [Required]
        public Guid ContractId { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [StringLength(50)]
        public string? PaymentMethod { get; set; }  // CreditCard, BankTransfer, ...

        [StringLength(50)]
        public string? ReferenceNumber { get; set; }  // Optional reference number for tracking

        public bool? IsLate { get; set; } = false;

        [Range(0, double.MaxValue, ErrorMessage = "Late fee must be a positive value.")]
        public decimal? LateFee { get; set; }  // Nullable if no late fee is applicable

        // Set the default value for Status to Pending
        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        [Required, Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }  // Payment amount with validation
    }
}
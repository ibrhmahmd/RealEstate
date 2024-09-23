using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOModels
{
    public class PaymentDTO : BaseEntity<Guid>
    {

        [Required]
        public Guid ContractId { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string? PaymentMethod { get; set; }  // e.g., CreditCard, BankTransfer, etc.
    }
}

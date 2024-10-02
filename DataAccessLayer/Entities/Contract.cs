using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
	public class Contract : BaseEntity<Guid>
	{
		[Required]
		public Guid PropertyId { get; set; }

		[Required]
		public Guid OccupantId { get; set; } // Renamed UserID to TenantId

		public Guid? AgentId { get; set; } // Optional agent who reviewed the contract

		[Required]
		public Guid? PaymentMethodId { get; set; } // Foreign Key for PaymentMethod


		public bool? IsArcheives { get; set; } = false;


        // Navigation Properties
        [ForeignKey("PropertyId")]
		public virtual Property Property { get; set; }

        [Required]
        public Guid? UserID { get; set; }
        public virtual User? User { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? MonthlyRent { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? SecurityDeposit { get; set; }

        // Navigation property
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}

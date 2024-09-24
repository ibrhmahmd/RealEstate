using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOModels
{
    public class ContractDTO : BaseEntity<Guid>
    {

        [Required]
        public Guid PropertyID { get; set; }

        [Required]
        public Guid? UserID { get; set; }

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

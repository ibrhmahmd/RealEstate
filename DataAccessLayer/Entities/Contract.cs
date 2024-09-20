using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Contract
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        public Guid PropertyID { get; set; }
        [ForeignKey("PropertyID")]
        public virtual Property Property { get; set; }

        [Required]
        public Guid UserID { get; set; }
        public virtual Resident User { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }

        [Range(0, double.MaxValue)]
        public float? MonthlyRent { get; set; }

        [Range(0, double.MaxValue)]
        public float? SecurityDeposit { get; set; }

        // Navigation property
        public virtual ICollection<Payment> Payments { get; set; }
    }
}

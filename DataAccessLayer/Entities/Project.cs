using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
	public class Project : BaseEntity<Guid>
	{
		[Required]
		[MaxLength(200)]
		public string ProjectName { get; set; }
		[MaxLength(500)]
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Status { get; set; }
		[ForeignKey("DeveloperCompanyId")]
		public DeveloperCompany DeveloperCompany { get; set; }
		public ICollection<Property> properties { get; set; }
	}
}
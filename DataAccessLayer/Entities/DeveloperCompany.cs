using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
	public class DeveloperCompany : BaseEntity<Guid>
	{
		[Required]
		[MaxLength(200)]
		public string CompanyName { get; set; }

		public int YearFounded { get; set; }

		[Required]
		[MaxLength(100)]
		public string Email { get; set; }

		[Phone]
		public string PhoneNumber { get; set; }

		[MaxLength(200)]
		public string Address { get; set; }

		[MaxLength(100)]
		public string City { get; set; }
		public ICollection<Project> Projects { get; set; }
	}
}
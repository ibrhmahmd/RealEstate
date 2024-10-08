using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOModels
{
	public class ProjectDTO : BaseEntity<Guid>
	{
		[Required]
		[MaxLength(200)]
		public string ProjectName { get; set; }
		[MaxLength(500)]
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Status { get; set; }

        public ICollection<Property>? properties { get; set; }

	}
}
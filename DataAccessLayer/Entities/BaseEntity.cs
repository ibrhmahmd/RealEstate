using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id{ get; set; }
        public T CreatedBy{ get; set; }
        public T UpdatedBy{ get; set; }
        public DateTime UpdatedOn{ get; set; }
        public DateTime CreatedOn{ get; set; } 
        public DateTime DeletedOn{ get; set; }
        public bool IsDeleted{ get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vemote.Domain.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [StringLength(28)]
        public string ID { get; set; }

        
        [StringLength(50)]
        public string DisplayName_Vie { get; set; }
        public string DisplayName_Eng { get; set; }
        public bool Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(28)]
        public string CreatedByID { get; set; }
        public virtual Users CreatedBy { get; set; }
        [StringLength(28)]
        public string UpdatedByID { get; set; }
        public virtual Users UpdatedBy { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}

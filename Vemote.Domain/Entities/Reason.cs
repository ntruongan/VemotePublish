using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Vemote.Domain.Entities
{
    [Table("Reason")]
    public class Reason
    {
        [Key]
        [StringLength(28)]
        public string ID { get; set; }

        public bool Status { get; set; }

        public String DisplayName_Eng { get; set; }
        public String DisplayName_Vie { get; set; }

        [StringLength(28)]
        public string OrderID { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(28)]
        public string CreatedByID { get; set; }
        public virtual Users CreatedBy { get; set; }
        [StringLength(28)]
        public string UpdatedByID { get; set; }
        public virtual Users UpdatedBy { get; set; }
    }
}

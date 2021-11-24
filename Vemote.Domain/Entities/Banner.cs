using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vemote.Domain.Entities
{
    [Table("Banner")]
    public class Banner
    {
        [Key]
        [StringLength(28)]
        public string ID { get; set; }

        public string Description_Eng { get; set; }
        public string Description_Vie { get; set; }

        public string PhotoUrl { get; set; }
        public DateTime ShowFrom { get; set; }
        public DateTime ShowTo { get; set; }
        public bool Status { get; set; }

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Domain.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [StringLength(28)]
        public string ID { get; set; }


        public DateTime Ordered { get; set; }
        public DateTime Done { get; set; }
        public DateTime Delivered { get; set; }
        public DateTime Canceled { get; set; }
        [StringLength(28)]
        public string CancelReasonID { get; set; }
        public virtual Reason CancelReason { get; set; }
        public bool Status { get; set; }
        public int TotolPrice { get; set; }
        [StringLength(28)]
        public string BelongToID { get; set; }
        public virtual Users OrderBy { get; set; }

        [StringLength(28)]
        public string ShipByID { get; set; }
        public virtual Users ShipBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(28)]
        public string CreatedByID { get; set; }
        public virtual Users CreatedBy { get; set; }
        [StringLength(28)]
        public string UpdatedByID { get; set; }
        public virtual Users UpdatedBy { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}

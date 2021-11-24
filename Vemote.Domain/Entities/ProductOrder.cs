using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vemote.Domain.Entities
{
    [Table("ProductOrder")]
    public class ProductOrder
    {
        [StringLength(28)]
        public String OrderID { get; set; }
        [StringLength(28)]
        public String ProductID { get; set; }

        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

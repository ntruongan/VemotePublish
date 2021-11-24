using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Vemote.Domain.Entities
{
    [Table("Favorite")]
    public class Favorite
    {
        [StringLength(28)]
        public string UserID { get; set; }
        [StringLength(28)]
        public string ProductID { get; set; }
        public bool Status { get; set; }
        public virtual Users User { get; set; }
        public virtual Product Product { get; set; }
    }
}

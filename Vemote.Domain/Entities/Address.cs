using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vemote.Domain.Entities
{
    [Table("Address")]
    public class Address
    {
        
        [StringLength(28)]
        public string UserID { get; set; }
        public virtual Users User { get; set; }
        public int ProvinceID { get; set; }
        public int DistrictID { get; set; }
        public int WardID { get; set; }
        public int AddressID { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Entities;

namespace Vemote.Application.DTOs
{
    public class ProductDTO
    {

        public string ID { get; set; }

        public string DisplayName_Vie { get; set; }
        public string DisplayName_Eng { get; set; }
        public string Description_Eng { get; set; }
        public string Description_Vie { get; set; }
        public string ImageUrl { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public int Inventory { get; set; }
        public bool Status { get; set; }
        public string CategoryID { get; set; }

        /*        public DateTime CreatedAt { get; set; }
                public DateTime UpdatedAt { get; set; }
                [StringLength(28)]
                public string CreatedByID { get; set; }
                public virtual User CreatedBy { get; set; }
                [StringLength(28)]
                public string UpdatedByID { get; set; }
                public virtual User UpdatedBy { get; set; }
                [StringLength(28)]
                public string CategoryID { get; set; }
                public virtual Category Category { get; set; }

                public virtual ICollection<ProductOrder> ProductOrders { get; set; }
                public virtual ICollection<Favorite> Favorites { get; set; }
                public virtual ICollection<Review> Reviews { get; set; }*/
    }
}

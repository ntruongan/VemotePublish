using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Application.DTOs
{
    public class ProductList
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public int TotalSize { get; set; }
        public int PageNumber { get; set; }
    }
}

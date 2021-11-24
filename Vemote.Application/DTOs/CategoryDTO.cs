using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Application.DTOs
{
    public class CategoryDTO
    {

        [StringLength(28)]
        public string ID { get; set; }


        [StringLength(50)]
        public string DisplayName_Vie { get; set; }
        public string DisplayName_Eng { get; set; }
        public bool Status { get; set; }


    }
}

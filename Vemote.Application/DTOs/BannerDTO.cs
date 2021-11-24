using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Application.DTOs
{
    public class BannerDTO
    {

        [StringLength(28)]
        public string ID { get; set; }

        public string Description_Eng { get; set; }
        public string Description_Vie { get; set; }

        public string PhotoUrl { get; set; }
        public DateTime ShowFrom { get; set; }
        public DateTime ShowTo { get; set; }
        public bool Status { get; set; }
    }
}

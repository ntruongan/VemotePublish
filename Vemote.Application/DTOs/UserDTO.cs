using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Application.DTOs
{
    public class UserDTO
    {

        
        [StringLength(28)]
        public string ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
        public bool Auth { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string UserTypeID { get; set; }
        public string Address { get; set; }
    }
}

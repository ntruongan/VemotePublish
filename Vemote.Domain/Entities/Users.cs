using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vemote.Domain.Entities
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [StringLength(28)]
        public string ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }
        //public virtual ICollection<Post> Posts { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string PhoneCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Status { get; set; }
        public bool Auth { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public string UserTypeID { get; set; }
        [StringLength(28)]
        public DateTime CreatedAt { get; set; }
        [StringLength(28)]
        public string CreatedByID { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(28)]
        public string UpdatedByID { get; set; }
        public virtual Users CreatedBy { get; set; }
        public virtual Users UpdatedBy { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Model
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(50)]
        public string  RoleName{ get; set; }
        [Required]
        [MaxLength(255)]
        public string Decription { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Role")]
    public class RoleEntity
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Decription { get; set; }

        //public virtual ICollection<UserEntity> Users { get; set; }
    }
}

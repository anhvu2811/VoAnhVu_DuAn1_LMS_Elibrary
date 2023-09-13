using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Model
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Avatar { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(40)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [ForeignKey("RoleId")]
        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Announcement_User> Announcement_Users { get; set; }
    }
}

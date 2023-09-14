using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Model
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubjectName { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

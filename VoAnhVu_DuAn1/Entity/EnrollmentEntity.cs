using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{ 
    [Table("Enrollment")]
    public class EnrollmentEntity
    {
        [Key]
        public string EnrollmentId { get; set; }
        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        [ForeignKey("SubjectId")]
        public string? SubjectId { get; set; }

        public virtual UserEntity? User { get; set; }
        public virtual SubjectEntity? Subject { get; set; }
    }
}

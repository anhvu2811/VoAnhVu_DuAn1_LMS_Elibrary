using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Subject")]
    public class SubjectEntity
    {
        [Key]
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public virtual ICollection<EnrollmentEntity> Enrollments { get; set; }
        public virtual ICollection<LectureEntity> Lectures { get; set; }
    }
}

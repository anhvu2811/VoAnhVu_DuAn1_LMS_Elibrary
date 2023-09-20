using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Lecture")]
    public class LectureEntity
    {
        [Key]
        public string LectureId { get; set; }
        public string Title { get; set; }
        public string FileUpload { get; set; }
        public string Time { get; set; }
        [ForeignKey("SubjectId")]
        public string? SubjectId { get; set; }
        public virtual SubjectEntity Subject { get; set; }
    }
}

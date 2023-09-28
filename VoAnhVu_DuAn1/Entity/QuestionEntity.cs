using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Question")]
    public class QuestionEntity
    {
        [Key]
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        [ForeignKey("LectureId")]
        public string? LectureId { get; set; }
        [ForeignKey("UserId")]
        public string? UserId { get; set; }
        public LectureEntity? Lecture { get; set; }
        public UserEntity? User { get; set; }
    }
}

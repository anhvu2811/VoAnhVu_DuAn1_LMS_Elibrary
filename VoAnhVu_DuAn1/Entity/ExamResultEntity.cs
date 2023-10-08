using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("ExamResult")]
    public class ExamResultEntity
    {
        [Key]
        public string ExamResultId { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        [ForeignKey("ExamId")]
        public string ExamId { get; set; }
        public float Score { get; set; }
        public UserEntity User { get; set; }
        public ExamEntity Exam { get; set; }
    }
}

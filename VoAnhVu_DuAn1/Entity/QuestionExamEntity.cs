using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("QuestionExam")]
    public class QuestionExamEntity
    {
        [Key]
        public string QuestionExamId { get; set; }
        [ForeignKey("ExamId")]
        public string? ExamId { get; set; }
        [ForeignKey("QuestionId")]
        public string? QuestionId { get; set; }
        public ExamEntity Exam { get; set; }
        public QuestionsEntity Question { get; set; }
    }
}

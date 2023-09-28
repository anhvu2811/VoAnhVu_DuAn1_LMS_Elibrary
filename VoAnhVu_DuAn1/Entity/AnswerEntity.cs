using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Answer")]
    public class AnswerEntity
    {
        [Key]
        public string AnswerId { get; set; }
        public string AnswerText { get; set; }
        [ForeignKey("QuestionId")]
        public string? QuestionId { get; set; }
        public QuestionEntity? Question { get; set; }
    }
}

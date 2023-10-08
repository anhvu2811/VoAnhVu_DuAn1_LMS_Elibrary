using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("Questions")]
    public class QuestionsEntity
    {
        [Key]
        public string QuestionId { get; set; }
        public string QuestionType { get; set; }
        public string QuestionName { get; set; }
        [ForeignKey("QuestionBankId")]
        public string? QuestionBankId { get; set; }
        public QuestionBankEntity? QuestionBank { get; set; }
    }
}

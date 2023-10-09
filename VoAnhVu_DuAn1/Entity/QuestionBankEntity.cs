using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Entity
{
    [Table("QuestionBank")]
    public class QuestionBankEntity
    {
        [Key]
        public string QuestionBankId { get; set; }
        public string QuestionBankName { get; set; }
        public string Level { get; set; }
    }
}

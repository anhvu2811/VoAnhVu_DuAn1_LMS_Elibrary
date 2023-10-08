using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class QuestionsModel
    {
        public string QuestionId { get; set; }
        public string QuestionType { get; set; }
        public string QuestionName { get; set; }
        public QuestionBankEntity QuestionBank { get; set; }
    }
}

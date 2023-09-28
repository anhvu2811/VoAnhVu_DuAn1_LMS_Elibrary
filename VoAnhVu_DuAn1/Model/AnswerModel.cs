using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class AnswerModel
    {
        public string AnswerId { get; set; }
        public string AnswerText { get; set; }
        public QuestionEntity Question { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class QuestionExamModel
    {
        public string QuestionExamId { get; set; }
        public ExamEntity Exam { get; set; }
        public QuestionsEntity Question { get; set; }
    }
}

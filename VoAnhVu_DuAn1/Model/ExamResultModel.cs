using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class ExamResultModel
    {
        public string ExamResultId { get; set; }
        public UserEntity User { get; set; }
        public ExamEntity Exam { get; set; }
        public float Score { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoAnhVu_DuAn1.Model
{
    public class ExamModel
    {
        public string ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
    }
}

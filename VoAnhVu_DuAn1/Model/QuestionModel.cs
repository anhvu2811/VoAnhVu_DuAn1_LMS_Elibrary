using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class QuestionModel
    {
        public string QuestionId { get; set; }
        public string QuestionText { get; set; }
        public LectureEntity Lecture { get; set; }
        public UserEntity User { get; set; }
    }
}

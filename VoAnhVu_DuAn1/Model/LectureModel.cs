using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class LectureModel
    {
        public string LectureId { get; set; }
        public string Title { get; set; }
        public string FileUpload { get; set; }
        public string Time { get; set; }
        public SubjectEntity Subject { get; set; }
    }
}

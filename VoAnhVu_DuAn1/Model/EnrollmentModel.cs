using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;

namespace VoAnhVu_DuAn1.Model
{
    public class EnrollmentModel
    {
        public string EnrollmentId { get; set; }
        public UserEntity? User { get; set; }
        public SubjectEntity? Subject { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IEnrollmentRepository
    {
        List<EnrollmentEntity> getAllEnrollment();
        void createEnrollment(EnrollmentEntity enrollment);
        void updateEnrollment(EnrollmentEntity enrolment);
        bool deleteEnrollment(string id);
    }
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly MyDbContext _context;
        public EnrollmentRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createEnrollment(EnrollmentEntity enrollment)
        {
            throw new NotImplementedException();
        }

        public bool deleteEnrollment(string id)
        {
            throw new NotImplementedException();
        }

        public List<EnrollmentEntity> getAllEnrollment()
        {
            throw new NotImplementedException();
        }

        public void updateEnrollment(EnrollmentEntity enrolment)
        {
            throw new NotImplementedException();
        }
    }
}

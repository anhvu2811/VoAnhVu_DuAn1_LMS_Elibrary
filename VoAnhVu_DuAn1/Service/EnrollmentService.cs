using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IEnrollmentService
    {
        List<EnrollmentModel> getAllEnrollment();
        void createEnrollment(EnrollmentEntity enrollment);
        void updateEnrollment(EnrollmentEntity enrollment);
        bool deleteEnrollment(string id);
        List<EnrollmentModel> getListSubject(string userId);
    }
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public void createEnrollment(EnrollmentEntity enrollment)
        {
            _enrollmentRepository.createEnrollment(enrollment);
        }

        public bool deleteEnrollment(string id)
        {
            bool enrollment = _enrollmentRepository.deleteEnrollment(id);
            if (!enrollment)
            {
                return false;
            }
            return true;
        }

        public List<EnrollmentModel> getAllEnrollment()
        {
            return _enrollmentRepository.getAllEnrollment().ToList();
        }

        public void updateEnrollment(EnrollmentEntity enrollment)
        {
            _enrollmentRepository.updateEnrollment(enrollment);
        }
        public List<EnrollmentModel> getListSubject(string userId)
        {
            return _enrollmentRepository.getListSubject(userId).ToList();
        }
    }
}

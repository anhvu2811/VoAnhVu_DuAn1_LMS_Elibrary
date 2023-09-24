using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        List<EnrollmentModel> getAllEnrollment();
        void createEnrollment(EnrollmentEntity enrollment);
        void updateEnrollment(EnrollmentEntity enrollment);
        bool deleteEnrollment(string id);
    }
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly MyDbContext _context;
        public EnrollmentRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createEnrollment([FromBody] EnrollmentEntity enrollment)
        {
            try
            {
                _context.EnrollmentEntities.Add(enrollment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteEnrollment(string id)
        {
            try
            {
                var enrollment = _context.EnrollmentEntities.FirstOrDefault(c => c.EnrollmentId == id);
                if (enrollment is null)
                {
                    return false;
                }
                _context.EnrollmentEntities.Remove(enrollment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EnrollmentModel> getAllEnrollment()
        {
            var enrollments = _context.EnrollmentEntities
              .Include(enrollment => enrollment.User)
              .Include(enrollment => enrollment.Subject)
              .Select(enroment => new EnrollmentModel
              {
                  EnrollmentId = enroment.EnrollmentId,
                  User = enroment.User,
                  Subject = enroment.Subject
              })
              .ToList();
            return enrollments;
        }

        public void updateEnrollment(EnrollmentEntity enrollment)
        {
            try
            {
                _context.EnrollmentEntities.Update(enrollment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IExamRepository
    {
        List<ExamEntity> getAllExam();
        void createExam(ExamEntity exam);
        void updateExam(ExamEntity exam);
        bool deleteExam(string id);
    }
    public class ExamRepository : IExamRepository
    {
        private readonly MyDbContext _context;
        public ExamRepository(MyDbContext context)
        {
            _context = context;
        }
        public void createExam(ExamEntity exam)
        {
            try
            {
                _context.ExamEntities.Add(exam);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteExam(string id)
        {
            try
            {
                var exam = _context.ExamEntities.FirstOrDefault(c => c.ExamId == id);
                if(exam is null)
                {
                    return false;
                }
                _context.ExamEntities.Remove(exam);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExamEntity> getAllExam()
        {
            return _context.ExamEntities.ToList();
        }

        public void updateExam(ExamEntity exam)
        {
            try
            {
                _context.ExamEntities.Update(exam);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

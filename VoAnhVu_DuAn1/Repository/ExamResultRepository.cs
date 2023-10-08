using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IExamResultRepository
    {
        List<ExamResultModel> getAllExamResult();
        void createExamResult(ExamResultEntity result);
        void updateExamResult(ExamResultEntity result);
        bool deleteExamResult(string id);
    }
    public class ExamResultRepository:IExamResultRepository
    {
        private readonly MyDbContext _context;
        public ExamResultRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createExamResult(ExamResultEntity result)
        {
            try
            {
                _context.ExamResultEntities.Add(result);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteExamResult(string id)
        {
            try
            {
                var result = _context.ExamResultEntities.FirstOrDefault(c => c.ExamResultId == id);
                if (result is null)
                {
                    return false;
                }
                _context.ExamResultEntities.Remove(result);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ExamResultModel> getAllExamResult()
        {
            var result = _context.ExamResultEntities
                .Include(re => re.User)
                .Include(re => re.Exam)
                .Select(re => new ExamResultModel
                {
                    ExamResultId = re.ExamResultId,
                    User = re.User,
                    Exam = re.Exam,
                    Score = re.Score,
                }).ToList();
            return result;
        }

        public void updateExamResult(ExamResultEntity result)
        {
            try
            {
                _context.ExamResultEntities.Update(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

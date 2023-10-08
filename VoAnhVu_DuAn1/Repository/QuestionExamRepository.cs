using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IQuestionExamRepository
    {
        List<QuestionExamModel> getAllQuestionExam();
        void createQuestionExam(QuestionExamEntity ques);
        void updateQuestionExam(QuestionExamEntity ques);
        bool deleteQuestionExam(string id);
    }
    public class QuestionExamRepository : IQuestionExamRepository
    {
        private readonly MyDbContext _context;
        public QuestionExamRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createQuestionExam(QuestionExamEntity ques)
        {
            try
            {
                _context.QuestionExamEntities.Add(ques);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteQuestionExam(string id)
        {
            try
            {
                var ques = _context.QuestionExamEntities.FirstOrDefault(c => c.QuestionExamId == id);
                if (ques is null)
                {
                    return false;
                }
                _context.QuestionExamEntities.Remove(ques);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<QuestionExamModel> getAllQuestionExam()
        {
            var ques = _context.QuestionExamEntities
                .Include(qe => qe.Exam)
                .Include(qe => qe.Question)
                .Select(qe => new QuestionExamModel
                {
                    QuestionExamId = qe.QuestionExamId,
                    Exam = qe.Exam,
                    Question = qe.Question
                }).ToList();
            return ques;
        }

        public void updateQuestionExam(QuestionExamEntity ques)
        {
            try
            {
                _context.QuestionExamEntities.Update(ques);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

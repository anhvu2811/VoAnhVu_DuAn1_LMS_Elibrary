using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IQuestionRepository
    {
        List<QuestionModel> getAllQuestion();
        void createQuestion(QuestionEntity question);
        void updateQuestion(QuestionEntity question);
        bool deleteQuestion(string id);
    }
    public class QuestionRepository : IQuestionRepository
    {
        private readonly MyDbContext _context;
        public QuestionRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createQuestion(QuestionEntity question)
        {
            try
            {
                _context.QuestionEntities.Add(question);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteQuestion(string id)
        {
            try
            {
                var question = _context.QuestionEntities.FirstOrDefault(c => c.QuestionId == id);
                if (question is null)
                {
                    return false;
                }
                _context.QuestionEntities.Remove(question);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<QuestionModel> getAllQuestion()
        {
            var questions = _context.QuestionEntities
             .Include(question => question.Lecture)
             .Include(question => question.User)
             .Select(question => new QuestionModel
             {
                 QuestionId = question.QuestionId,
                 QuestionText = question.QuestionText,
                 Lecture = question.Lecture,
                 User = question.User
             }).ToList();
            return questions;
        }

        public void updateQuestion(QuestionEntity question)
        {
            try
            {
                _context.QuestionEntities.Update(question);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IQuestionsRepository
    {
        List<QuestionsModel> getAllQuestion();
        void createQuestion(QuestionsEntity ques);
        void updateQuestion(QuestionsEntity ques);
        bool deleteQuestion(string id);
    }
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly MyDbContext _context;
        public QuestionsRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createQuestion(QuestionsEntity ques)
        {
            try
            {
                _context.QuestionsEntities.Add(ques);
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
                var ques = _context.QuestionsEntities.FirstOrDefault(c => c.QuestionId == id);
                if (ques is null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<QuestionsModel> getAllQuestion()
        {
            var ques = _context.QuestionsEntities
                .Include(qe => qe.QuestionBank)
                .Select(qe => new QuestionsModel
                {
                    QuestionId = qe.QuestionId,
                    QuestionType = qe.QuestionType,
                    QuestionName = qe.QuestionName,
                    QuestionBank = qe.QuestionBank
                }).ToList();
            return ques;
        }

        public void updateQuestion(QuestionsEntity ques)
        {
            try
            {
                _context.QuestionsEntities.Update(ques);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

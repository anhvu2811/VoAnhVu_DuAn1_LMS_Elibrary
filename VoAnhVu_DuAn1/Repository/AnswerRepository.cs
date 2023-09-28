using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IAnswerRepository
    {
        List<AnswerModel> getAllAnswer();
        void createAnswer(AnswerEntity answer);
        void updateAnswer(AnswerEntity answer);
        bool deleteAnswer(string id);
    }
    public class AnswerRepository : IAnswerRepository
    {
        private readonly MyDbContext _context;
        public AnswerRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createAnswer(AnswerEntity answer)
        {
            try
            {
                _context.AnswerEntities.Add(answer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteAnswer(string id)
        {
            try
            {
                var answer = _context.AnswerEntities.FirstOrDefault(c => c.AnswerId == id);
                if (answer is null)
                {
                    return false;
                }
                _context.AnswerEntities.Remove(answer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AnswerModel> getAllAnswer()
        {
            var answers = _context.AnswerEntities
             .Include(answer => answer.Question)
             .Select(answer => new AnswerModel
             {
                 AnswerId = answer.AnswerId,
                 AnswerText = answer.AnswerText,
                 Question = answer.Question
             }).ToList();
            return answers;
        }

        public void updateAnswer(AnswerEntity answer)
        {
            try
            {
                _context.AnswerEntities.Update(answer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

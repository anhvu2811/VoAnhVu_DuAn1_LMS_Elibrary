using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IQuestionBankRepository
    {
        List<QuestionBankEntity> getAllQuestionBank();
        void createQuestionBank(QuestionBankEntity qb);
        void updateQuestionBank(QuestionBankEntity qb);
        bool deleteQuestionBank(string id);
    }
    public class QuestionBankRepository : IQuestionBankRepository
    {
        private readonly MyDbContext _context;
        public QuestionBankRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createQuestionBank(QuestionBankEntity qb)
        {
            try
            {
                _context.QuestionBankEntities.Add(qb);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteQuestionBank(string id)
        {
            try
            {
                var qb = _context.QuestionBankEntities.FirstOrDefault(c => c.QuestionBankId == id);
                if (qb is null)
                {
                    return false;
                }
                _context.QuestionBankEntities.Remove(qb);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<QuestionBankEntity> getAllQuestionBank()
        {
            var ql = _context.QuestionBankEntities.ToList();
            return ql;
        }

        public void updateQuestionBank(QuestionBankEntity qb)
        {
            try
            {
                _context.QuestionBankEntities.Update(qb);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

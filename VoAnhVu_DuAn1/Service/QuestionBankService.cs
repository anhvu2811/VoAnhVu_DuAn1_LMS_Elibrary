using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IQuestionBankService
    {
        List<QuestionBankEntity> getAllQuestionBank();
        void createQuestionBank(QuestionBankEntity qb);
        void updateQuestionBank(QuestionBankEntity qb);
        bool deleteQuestionBank(string id);
    }
    public class QuestionBankService : IQuestionBankService
    {
        private readonly IQuestionBankRepository _questionBankRepository;
        public QuestionBankService(IQuestionBankRepository questionBankRepository)
        {
            _questionBankRepository = questionBankRepository;
        }

        public void createQuestionBank(QuestionBankEntity qb)
        {
            _questionBankRepository.createQuestionBank(qb);
        }

        public bool deleteQuestionBank(string id)
        {
            bool qb = _questionBankRepository.deleteQuestionBank(id);
            if (!qb)
            {
                return false;
            }
            return true;
        }

        public List<QuestionBankEntity> getAllQuestionBank()
        {
            return _questionBankRepository.getAllQuestionBank().ToList();
        }

        public void updateQuestionBank(QuestionBankEntity qb)
        {
            _questionBankRepository.updateQuestionBank(qb);
        }
    }
}

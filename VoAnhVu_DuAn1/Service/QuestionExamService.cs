using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IQuestionExamService
    {
        List<QuestionExamModel> getAllQuestionExam();
        void createQuestionExam(QuestionExamEntity ques);
        void updateQuestionExam(QuestionExamEntity ques);
        bool deleteQuestionExam(string id);
    }
    public class QuestionExamService : IQuestionExamService
    {
        private readonly IQuestionExamRepository _questionExamRepository;
        public QuestionExamService(IQuestionExamRepository questionExamRepository)
        {
            _questionExamRepository = questionExamRepository;
        }
        public void createQuestionExam(QuestionExamEntity ques)
        {
            _questionExamRepository.createQuestionExam(ques);
        }

        public bool deleteQuestionExam(string id)
        {
            bool ques = _questionExamRepository.deleteQuestionExam(id);
            if (!ques)
            {
                return false;
            }
            return true;
        }

        public List<QuestionExamModel> getAllQuestionExam()
        {
            return _questionExamRepository.getAllQuestionExam();
        }

        public void updateQuestionExam(QuestionExamEntity ques)
        {
            _questionExamRepository.updateQuestionExam(ques);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IQuestionService
    {
        List<QuestionModel> getAllQuestion();
        void createQuestion(QuestionEntity question);
        void updateQuestion(QuestionEntity question);
        bool deleteQuestion(string id);
    }
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public void createQuestion(QuestionEntity question)
        {
            _questionRepository.createQuestion(question);
        }

        public bool deleteQuestion(string id)
        {
            bool user = _questionRepository.deleteQuestion(id);
            if (!user)
            {
                return false;
            }
            return true;
        }

        public List<QuestionModel> getAllQuestion()
        {
            return _questionRepository.getAllQuestion().ToList();
        }

        public void updateQuestion(QuestionEntity question)
        {
            _questionRepository.updateQuestion(question);
        }
    }
}

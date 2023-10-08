using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IQuestionsService
    {
        List<QuestionsModel> getAllQuestionExam();
        void createQuestionExam(QuestionsEntity ques);
        void updateQuestionExam(QuestionsEntity ques);
        bool deleteQuestionExam(string id);
    }
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionsRepository;
        public QuestionsService(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        public void createQuestionExam(QuestionsEntity ques)
        {
            _questionsRepository.createQuestion(ques);
        }

        public bool deleteQuestionExam(string id)
        {
            bool ques = _questionsRepository.deleteQuestion(id);
            if (!ques)
            {
                return false;
            }
            return true;
        }

        public List<QuestionsModel> getAllQuestionExam()
        {
            return _questionsRepository.getAllQuestion().ToList();
        }

        public void updateQuestionExam(QuestionsEntity ques)
        {
            _questionsRepository.updateQuestion(ques);
        }
    }
}

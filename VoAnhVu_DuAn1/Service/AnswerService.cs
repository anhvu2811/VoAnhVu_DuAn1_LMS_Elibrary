using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IAnswerService
    {
        List<AnswerModel> getAllAnswer();
        void createAnswer(AnswerEntity answer);
        void updateAnswer(AnswerEntity answer);
        bool deleteAnswer(string id);
    }
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public void createAnswer(AnswerEntity answer)
        {
            _answerRepository.createAnswer(answer);
        }

        public bool deleteAnswer(string id)
        {
            bool answer = _answerRepository.deleteAnswer(id);
            if (!answer)
            {
                return false;
            }
            return true;
        }

        public List<AnswerModel> getAllAnswer()
        {
            return _answerRepository.getAllAnswer().ToList();
        }

        public void updateAnswer(AnswerEntity answer)
        {
            _answerRepository.updateAnswer(answer);
        }
    }
}

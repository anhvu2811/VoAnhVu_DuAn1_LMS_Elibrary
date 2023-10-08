using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IExamResultService
    {
        List<ExamResultModel> getAllExamResult();
        void createExamResult(ExamResultEntity result);
        void updateExamResult(ExamResultEntity result);
        bool deleteExamResult(string id);
    }
    public class ExamResultService : IExamResultService 
    {
        private readonly IExamResultRepository _examResultRepository;
        public ExamResultService(IExamResultRepository examResultRepository)
        {
            _examResultRepository = examResultRepository;
        }

        public void createExamResult(ExamResultEntity result)
        {
            _examResultRepository.createExamResult(result);
        }

        public bool deleteExamResult(string id)
        {
            bool result = _examResultRepository.deleteExamResult(id);
            if (!result)
            {
                return false;
            }
            return true;
        }

        public List<ExamResultModel> getAllExamResult()
        {
            return _examResultRepository.getAllExamResult();
        }

        public void updateExamResult(ExamResultEntity result)
        {
            _examResultRepository.updateExamResult(result);
        }
    }
}

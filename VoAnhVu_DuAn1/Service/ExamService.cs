using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IExamService
    {
        List<ExamEntity> getAllExam();
        void createExam(ExamEntity exam);
        void updateExam(ExamEntity exam);
        bool deleteExam(string id);
    }
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public void createExam(ExamEntity exam)
        {
            _examRepository.createExam(exam);
        }

        public bool deleteExam(string id)
        {
            bool exam = _examRepository.deleteExam(id);
            if (!exam)
            {
                return false;
            }
            return true;
        }

        public List<ExamEntity> getAllExam()
        {
            return _examRepository.getAllExam().ToList();
        }

        public void updateExam(ExamEntity exam)
        {
            _examRepository.updateExam(exam);
        }
    }
}

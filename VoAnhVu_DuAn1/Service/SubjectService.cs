using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface ISubjectService
    {
        List<SubjectEntity> getAllSubject();
        List<SubjectEntity> searchSubject(string key);
        List<SubjectEntity> sortSubject(string sortBy, bool ascending);
        SubjectEntity getSubjectById(string id);
        void createSubject(SubjectEntity subject);
        void updateSubject(SubjectEntity subject);
        bool deleteSubject(string id);
    }
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public void createSubject(SubjectEntity subject)
        {
            _subjectRepository.createSubject(subject);
        }

        public bool deleteSubject(string id)
        {
            bool subject = _subjectRepository.deleteSubject(id);
            if (!subject)
            {
                return false;
            }
            return true;
        }

        public List<SubjectEntity> getAllSubject()
        {
            return _subjectRepository.getAllSubject().ToList();
        }

        public List<SubjectEntity> searchSubject(string key)
        {
            return _subjectRepository.getAllSubject().Where(c => c.SubjectName.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void updateSubject(SubjectEntity subject)
        {
            _subjectRepository.updateSubject(subject);
        }

        public List<SubjectEntity> sortSubject(string sortBy, bool ascending)
        {
            var subject = _subjectRepository.getAllSubject();
            switch (sortBy.ToLower())
            {
                case "subjectname":
                    subject = ascending
                    ? subject.OrderBy(s => s.SubjectName).ToList()
                    : subject.OrderByDescending(s => s.SubjectName).ToList();
                    break;
                case "subjectid":
                    subject = ascending
                    ? subject.OrderBy(s => s.SubjectId).ToList()
                    : subject.OrderByDescending(s => s.SubjectId).ToList();
                    break;
                default:
                    break;
            }
            return subject;
        }

        public SubjectEntity getSubjectById(string id)
        {
            return _subjectRepository.getSubjectById(id);
        }
    }
}

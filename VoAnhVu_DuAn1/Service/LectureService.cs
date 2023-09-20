using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface ILectureService
    {
        List<LectureModel> getAllLecture();
        void createLecture(LectureEntity lecture);
        void updateLecture(LectureEntity lecture);
        bool deleteLecture(string id);
    }
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepository;
        public LectureService(ILectureRepository lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }

        public void createLecture(LectureEntity lecture)
        {
            _lectureRepository.createLecture(lecture);
        }

        public bool deleteLecture(string id)
        {
            bool lecture = _lectureRepository.deleteLecture(id);
            if (!lecture)
            {
                return false;
            }
            return true;
        }

        public List<LectureModel> getAllLecture()
        {
            return _lectureRepository.getAllLecture().ToList();
        }

        public void updateLecture(LectureEntity lecture)
        {
            _lectureRepository.updateLecture(lecture);
        }
    }
}

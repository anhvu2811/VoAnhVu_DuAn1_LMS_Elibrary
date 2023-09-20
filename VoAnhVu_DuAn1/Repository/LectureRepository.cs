using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface ILectureRepository
    {
        List<LectureModel> getAllLecture();
        void createLecture(LectureEntity lecture);
        void updateLecture(LectureEntity lecture);
        bool deleteLecture(string id);
    }
    public class LectureRepository : ILectureRepository
    {
        private readonly MyDbContext _context;
        public LectureRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createLecture(LectureEntity lecture)
        {
            try
            {
                _context.LectureEntities.Add(lecture);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteLecture(string id)
        {
            try
            {
                var lecture = _context.LectureEntities.FirstOrDefault(c => c.LectureId == id);
                if (lecture is null)
                {
                    return false;
                }
                _context.LectureEntities.Remove(lecture);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LectureModel> getAllLecture()
        {
            var lectures = _context.LectureEntities
             .Include(lecture => lecture.Subject) 
             .Select(lecture => new LectureModel
             {
                 LectureId = lecture.LectureId,
                 Title = lecture.Title,
                 FileUpload = lecture.FileUpload,
                 Time = lecture.Time,
                 SubjectName = lecture.Subject != null ? lecture.Subject.SubjectName : "Unknown"
                 // Không bao gồm RoleId trong UserModel
             })
             .ToList();

            return lectures;
        }

        public void updateLecture(LectureEntity lecture)
        {
            try
            {
                _context.LectureEntities.Update(lecture);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

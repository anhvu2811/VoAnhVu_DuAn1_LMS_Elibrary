using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface ISubjectRepository
    {
        List<SubjectModel> getAllSubject();
        SubjectEntity getSubjectById(string id);
        void createSubject(SubjectEntity subject);
        void updateSubject(SubjectEntity subject);
        bool deleteSubject(string id);
    }
    public class SubjectRepository : ISubjectRepository
    {
        private readonly MyDbContext _context;
        public SubjectRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createSubject([FromBody]SubjectEntity subject)
        {
            try
            {
                _context.SubjectEntities.Add(subject);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteSubject(string id)
        {
            try
            {
                var subject = _context.SubjectEntities.FirstOrDefault(c => c.SubjectId == id);
                if(subject is null)
                {
                    return false;
                }
                _context.SubjectEntities.Remove(subject);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SubjectModel> getAllSubject()
        {
            var subjects = _context.SubjectEntities
             .Include(subject => subject.Topic)
             .Select(subject => new SubjectModel
             {
                 SubjectId = subject.SubjectId,
                 SubjectName = subject.SubjectName,
                 Topic = subject.Topic
             }).ToList();
            return subjects;
        }

        public SubjectEntity getSubjectById(string id)
        {
            var subject = _context.SubjectEntities.FirstOrDefault(c => c.SubjectId == id);
            return subject;
        }

        public void updateSubject(SubjectEntity subject)
        {
            try
            {
                _context.SubjectEntities.Update(subject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

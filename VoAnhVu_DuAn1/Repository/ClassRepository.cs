using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IClassRepository
    {
        List<ClassEntity> getAllClass();
        void createClass(ClassEntity cl);
        void updateClass(ClassEntity cl);
        bool deleteClass(string id);
    }
    public class ClassRepository :IClassRepository
    {
        private readonly MyDbContext _context;
        public ClassRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createClass(ClassEntity cl)
        {
            try
            {
                _context.ClassEntities.Add(cl);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteClass(string id)
        {
            try
            {
                var cl = _context.ClassEntities.FirstOrDefault(c => c.ClassId == id);
                if (cl is null)
                {
                    return false;
                }
                _context.ClassEntities.Remove(cl);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClassEntity> getAllClass()
        {
            var cl = _context.ClassEntities.ToList();
            return cl;
        }

        public void updateClass(ClassEntity cl)
        {
            try
            {
                _context.ClassEntities.Update(cl);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

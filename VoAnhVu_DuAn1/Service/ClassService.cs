using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IClassService
    {
        List<ClassEntity> getAllClass();
        void createClass(ClassEntity cl);
        void updateClass(ClassEntity cl);
        bool deleteClass(string id);
    }
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public void createClass(ClassEntity cl)
        {
            _classRepository.createClass(cl);
        }

        public bool deleteClass(string id)
        {
            bool cl = _classRepository.deleteClass(id);
            if (!cl)
            {
                return false;
            }
            return true;
        }

        public List<ClassEntity> getAllClass()
        {
            return _classRepository.getAllClass().ToList();
        }

        public void updateClass(ClassEntity cl)
        {
            _classRepository.updateClass(cl);
        }
    }
}

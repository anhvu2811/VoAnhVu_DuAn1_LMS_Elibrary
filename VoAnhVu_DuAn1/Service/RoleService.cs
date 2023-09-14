using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IRoleService
    {
        List<RoleEntity> getAllRole();
        List<RoleEntity> searchRole(string key);
        RoleEntity getRoleById(string id);
        void createRole(RoleEntity role);
        void updateRole(RoleEntity role);
        bool deleteRole(string id);
    }
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public void createRole(RoleEntity role)
        {
            _roleRepository.createRole(role);
        }

        public bool deleteRole(string id)
        {
            bool role = _roleRepository.deleteRole(id);
            if (!role)
            {
                return false;
            }
            return true;
        }

        public List<RoleEntity> getAllRole()
        {
            return _roleRepository.getAllRole().ToList();
        }
        public List<RoleEntity> searchRole(string key)
        {
            return _roleRepository.getAllRole().Where(c =>
            c.RoleId.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
            c.RoleName.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public RoleEntity getRoleById(string id)
        {
            return _roleRepository.getRoleById(id);
        }

        public void updateRole(RoleEntity role)
        {
            _roleRepository.updateRole(role);
        }
    }
}

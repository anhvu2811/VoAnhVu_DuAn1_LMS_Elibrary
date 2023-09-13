using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Services
{
    public class RoleService
    {
        private readonly MyDbContext _context;

        public RoleService(MyDbContext context)
        {
            _context = context;
        }
        //Get ALl
        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }
        //Create
        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }
        //Delete
        public void DeleteRole(int roleId)
        {
            var roleDelete = _context.Roles.Find(roleId);
            if(roleDelete != null)
            {
                _context.Roles.Remove(roleDelete);
                _context.SaveChanges();
            }
        }
        //Edit
        public void UpdateRole(int id, Role updateRole)
        {
            var role = _context.Roles.Find(updateRole.RoleId);
            if(role != null)
            {
                role.RoleName = updateRole.RoleName;
                role.Decription = updateRole.Decription;

                _context.SaveChanges();
            }
        }
    }
}

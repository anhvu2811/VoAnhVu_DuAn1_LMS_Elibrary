using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IRoleRepository
    {
        List<RoleEntity> getAllRole();
        RoleEntity getRoleById(string id);
        void createRole(RoleEntity role);
        void updateRole(RoleEntity role);
        bool deleteRole(string id);
    }
    public class RoleRepository : IRoleRepository
    {
        private readonly MyDbContext _context;
        public RoleRepository(MyDbContext context)
        {
            _context = context;
        }
        public void createRole([FromBody] RoleEntity role)
        {
            try
            {
                _context.RoleEntities.Add(role);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteRole(string id)
        {
            try
            {
                var role = _context.RoleEntities.FirstOrDefault(c => c.RoleId == id);
                if(role is null)
                {
                    return false;
                }
                _context.RoleEntities.Remove(role);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RoleEntity> getAllRole()
        {
            var role = _context.RoleEntities.ToList();
            return role;
        }

        public RoleEntity getRoleById(string id)
        {
            var role = _context.RoleEntities.FirstOrDefault(c => c.RoleId == id);
            return role;
        }

        public void updateRole(RoleEntity role)
        {
            try
            {
                _context.RoleEntities.Update(role);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Repository
{
    public interface IUserRepository
    {
        List<UserEntity> getAllUser();
        UserEntity getUserById(string id);
        void createUser(UserEntity user);
        void updateUser(UserEntity user);
        bool deleteUser(string id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public void createUser([FromBody] UserEntity user)
        {
            try
            {
                _context.UserEntities.Add(user);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool deleteUser(string id)
        {
            try
            {
                var user = _context.UserEntities.FirstOrDefault(c => c.UserId == id);
                if(user is null)
                {
                    return false;
                }
                _context.UserEntities.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserEntity> getAllUser()
        {
            return _context.UserEntities.ToList();
        }

        public UserEntity getUserById(string id)
        {
            var role = _context.UserEntities.FirstOrDefault(c => c.RoleId == id);
            return role;
        }

        public void updateUser(UserEntity user)
        {
            try
            {
                _context.UserEntities.Update(user);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

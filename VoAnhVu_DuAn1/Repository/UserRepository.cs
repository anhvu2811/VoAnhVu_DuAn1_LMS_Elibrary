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
    public interface IUserRepository
    {
        List<UserModel> getAllUser();
        UserModel getUserById(string id);
        void createUser(UserEntity user);
        void updateUser(UserEntity user);
        bool deleteUser(string id);
        UserEntity GetUserByUsernameAndPassword(string username, string password);
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

        public List<UserModel> getAllUser()
        {
            var users = _context.UserEntities
             .Include(user => user.Role) // Bao gồm thông tin từ bảng Role
             .Select(user => new UserModel
             {
                 UserId = user.UserId,
                 Avatar = user.Avatar,
                 FullName = user.FullName,
                 Gender = user.Gender,
                 Email = user.Email,
                 Phone = user.Phone,
                 Address = user.Address,
                 Username = user.Username,
                 RoleName = user.Role != null ? user.Role.RoleName : "Unknown"
                // Không bao gồm RoleId trong UserModel
            })
             .ToList();

            return users;
        }

        public UserModel getUserById(string id)
        {
            var userEntity = _context.UserEntities.Include(user => user.Role).FirstOrDefault(c => c.UserId == id);
            if (userEntity != null)
            {
                var userModel = new UserModel
                {
                    UserId = userEntity.UserId,
                    Avatar = userEntity.Avatar,
                    FullName = userEntity.FullName,
                    Gender = userEntity.Gender,
                    Email = userEntity.Email,
                    Phone = userEntity.Phone,
                    Address = userEntity.Address,
                    Username = userEntity.Username,
                    RoleName = userEntity.Role != null ? userEntity.Role.RoleName : "Unknown"
                };

                return userModel;
            }
            return null; 
        }

        public void updateUser(UserEntity user)
        {
            try
            {
                _context.UserEntities.Update(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserEntity GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.UserEntities.SingleOrDefault(p => p.Username == username && p.Password == password);
        }
    }
}

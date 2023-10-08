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
        void changePassword(string id, string oldPassword, string newPassword);
        string getRoleNameByUserId(string id);
        void updateAvatar(string id, string avatarUrl);
        void deleteAvatar(string id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepository(MyDbContext context)
        {
            _context = context;
        }
        public void createUser(UserEntity user)
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
                 .Include(user => user.Role) 
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
                     Password = user.Password,
                     Role = user.Role
                }).ToList();
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
                    Password = userEntity.Password,
                    Role = userEntity.Role
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
        public void changePassword(string userId, string oldPassword, string newPassword)
        {
            try
            {
                var user = _context.UserEntities.FirstOrDefault(c => c.UserId == userId);
                if (user != null)
                {
                    if (user.Password == oldPassword)
                    {
                        user.Password = newPassword;
                        _context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Mật khẩu cũ không đúng.");
                    }
                }
                else
                {
                    throw new Exception("Người dùng không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updateAvatar(string id, string avatarUrl)
        {
            try
            {
                var user = _context.UserEntities.FirstOrDefault(u => u.UserId == id);
                if(user != null)
                {
                    user.Avatar = avatarUrl;
                    _context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void deleteAvatar(string id)
        {
            try
            {
                var user = _context.UserEntities.FirstOrDefault(u => u.UserId == id);
                if (user != null)
                {
                    user.Avatar = null; 
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string getRoleNameByUserId(string id)
        {
            var roleName = _context.UserEntities
                .Where(u => u.UserId == id)
                .Select(u => u.Role.RoleName)
                .FirstOrDefault();
            return roleName;
        }
    }
}

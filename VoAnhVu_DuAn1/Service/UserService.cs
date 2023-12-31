﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IUserService
    {
        List<UserModel> getAllUser();
        List<UserModel> searchUser(string key);
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void createUser(UserEntity user)
        {
            _userRepository.createUser(user);
        }
        public bool deleteUser(string id)
        {
            bool user = _userRepository.deleteUser(id);
            if (!user)
            {
                return false;
            }
            return true;
        }
        public UserModel getUserById(string id)
        {
            return _userRepository.getUserById(id);
        }
        public List<UserModel> getAllUser()
        {
            return _userRepository.getAllUser().ToList();
        }
        public List<UserModel> searchUser(string key)
        {
            return _userRepository.getAllUser().Where(c =>
                c.UserId.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.FullName.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Gender.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();
        }
        public void updateUser(UserEntity user)
        {
            _userRepository.updateUser(user);
        }
        public UserEntity GetUserByUsernameAndPassword(string username, string password)
        {
            return _userRepository.GetUserByUsernameAndPassword(username, password);
        }
        public void changePassword(string id, string oldPassword, string newPassword)
        {
            try
            {
                _userRepository.changePassword(id, oldPassword, newPassword);
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
                _userRepository.updateAvatar(id, avatarUrl);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deleteAvatar(string id)
        {
            try
            {
                _userRepository.deleteAvatar(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string getRoleNameByUserId(string id)
        {
            return _userRepository.getRoleNameByUserId(id);
        }

    }
}

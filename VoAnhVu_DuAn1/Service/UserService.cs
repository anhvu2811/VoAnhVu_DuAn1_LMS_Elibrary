using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Entity;
using VoAnhVu_DuAn1.Repository;

namespace VoAnhVu_DuAn1.Service
{
    public interface IUserService
    {
        List<UserEntity> getAllUser();
        List<UserEntity> searchUser(string key);
        UserEntity getUserById(string id);
        void createUser(UserEntity user);
        void updateUser(UserEntity user);
        bool deleteUser(string id);
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

        public UserEntity getUserById(string id)
        {
            return _userRepository.getUserById(id);
        }

        public List<UserEntity> getAllUser()
        {
            return _userRepository.getAllUser().ToList();
        }

        public List<UserEntity> searchUser(string key)
        {
            return _userRepository.getAllUser().Where(c =>
                c.UserId.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.FullName.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Gender.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Email.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Phone.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Address.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Username.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.Password.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0 ||
                c.RoleId.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();
        }

        public void updateUser(UserEntity user)
        {
            _userRepository.updateUser(user);
        }
    }
}

using StudyMateLibrary.Enities;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;

namespace StudyMateLibrary.Domains
{
    public class UserDomain : CommonDomain<User>, IDisposable
    {
        private IRepository<User> _userRepository;

        public UserDomain()
        {
            _userRepository = new Repository<User>();
        }

        public UserDomain(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ChangePassord(string userId, string Password)
        {
            ValdateUserId(userId);

            var user = _userRepository.Get(u => u.Id == userId);
            user.Password = Password;

            _userRepository.UpdateOne(u => u.Id == user.Id, user);

            return true;
        }

        public IEnumerable<User> List()
        {
            return _userRepository.List();
        }

        private void ValdateUserId(string userId)
        {
            var count = _userRepository.Count(u => u.Id == userId);
            if (count == 0) throw new ArgumentException("User  Not present in System ");
        }

        private void validateUserName(User user)
        {
            var count = _userRepository.Count(u => u.UserName == user.UserName);
            if (count > 0)
            {
                throw new ArgumentException("UserName already pressent");
            }
        }
    }
}
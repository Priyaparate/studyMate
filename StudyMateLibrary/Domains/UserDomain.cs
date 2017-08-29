using StudyMateLibrary.Enities;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;

namespace StudyMateLibrary.Domains
{
    public class UserDomain : CommonDomain<User>
    {
        public UserDomain()
        {
            _repository = new Repository<User>();
        }

        public UserDomain(IRepository<User> userRepository)
        {
            _repository = userRepository;
        }

        public bool ChangePassord(string userId, string Password)
        {
            ValdateUserId(userId);

            var user = _repository.Get(u => u.Id == userId);
            user.Password = Password;

            _repository.UpdateOne(u => u.Id == user.Id, user);

            return true;
        }

        public IEnumerable<User> List()
        {
            return _repository.List();
        }

        private void ValdateUserId(string userId)
        {
            var count = _repository.Count(u => u.Id == userId);
            if (count == 0) throw new ArgumentException("User  Not present in System ");
        }

        private void validateUserName(User user)
        {
            var count = _repository.Count(u => u.UserName == user.UserName);
            if (count > 0)
            {
                throw new ArgumentException("UserName already pressent");
            }
        }
    }
}
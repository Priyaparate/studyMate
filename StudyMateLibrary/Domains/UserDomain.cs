using StudyMateLibrary.Enities;
using StudyMateLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudyMateLibrary.Domains
{
    public class UserDomain :CommonDomain<User>,IDisposable
    {
        private  IRepository<User> _userRepository;

        public UserDomain()
        {
            _userRepository = new Repository<User>();
        }

        public UserDomain(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        //public bool AddUser(User user)
        //{
        //    ValdateUser(user);
        //    validateUserName(user);

        //    user.GuidId = new Guid();
        //    user.UserId = _userRepository.Count() + 1;

        //    _userRepository.Add(user);

        //    return true;
        //}

        public bool ChangePassord(string userId, string Password)
        {
            ValdateUserId(userId);

            var user = _userRepository.Get(u => u.Id == userId);
            user.Password = Password;

            _userRepository.UpdateOne(u=>u.Id==user.Id, user);

            return true;
        }

       
        //public User GetUser(Expression<Func<User,bool>> filter)
        //{
            
        //    return _userRepository.Get(filter);
        //}

        public IEnumerable<User> List()
        {
            return _userRepository.List();
        }

        //public bool UpdateUser(int userId, User user)
        //{
        //    ValdateUser(user);
        //    ValdateUserId(userId);

        //    _userRepository.UpdateOne(u => u.UserId == user.UserId, user);
        //    return true;
        //}
        //public bool Delete(Expression<Func<User, bool>> filter)
        //{
        //    return _userRepository.Delete(filter);

        //}

        //private void ValdateUser(User user)
        //{
        //    if (user == null) throw new ArgumentException("User object not valid");
        //}

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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudyMateLibrary.Enities;
using StudyMateLibrary.Repository;
using StudyMateLibrary.Domains;
using System;
using System.Linq.Expressions;

namespace StudyMateLibrary.Test.DomainTest
{
    [TestClass]
    public class UserDomainTest
    {
        private Mock<IRepository<User>> _mockUserRepository;
        private UserDomain _userDomain;

        [TestCleanup]
        public void cleanup()
        {
            _mockUserRepository = null;
            _userDomain = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_NullUser_WhenCreate_ThenUserShouldNotCreated()
        {
            _userDomain.Add(null);
        }

        [TestMethod]
        public void Given_User_WhenCreate_ThenUserShouldCreated()
        {
            //Arrage
            var user = GetUser();
            _mockUserRepository.Setup(m => m.Add(user));
            //act
            _userDomain.Add(user);

            //Asert
            _mockUserRepository.Verify(x => x.Add(user), Times.AtMostOnce());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_UserWithExistingUserName_WhenCreate_ThenUserShouldNotCreated()
        {
            //Arrage
            var user = GetUser();
            _mockUserRepository.Setup(m => m.Count(It.IsAny<Func<User, bool>>())).Returns(1);
            //act
            _userDomain.Add(user);
            //Asert
        }

        [TestMethod]
        public void Given_UseIdAndPassword_WhenPasswordChange_ThenPasswordChange()
        {
            //Arrage
            var user = GetUser();
            _mockUserRepository.Setup(m => m.Count(It.IsAny<Func<User, bool>>())).Returns(1);
            _mockUserRepository.Setup(m=>m.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
            _mockUserRepository.Setup(m => m.Update(user.Id.ToString(),user));
            //act
            _userDomain.ChangePassord(user.Id, user.Password);
            //Asert
            _mockUserRepository.Verify(x => x.Count(It.IsAny<Func<User, bool>>()), Times.AtMostOnce());
            _mockUserRepository.Verify(x => x.Get(It.IsAny<Expression<Func<User, bool>>>()), Times.AtMostOnce());
            _mockUserRepository.Verify(x => x.Update(user.Id.ToString(),user), Times.AtMostOnce());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Given_IdAndPassword_WhenPasswordChangeAndUserNotPresent_ThenPasswordShouldNotChange()
        {
            //Arrage
            var user = GetUser();
            _mockUserRepository.Setup(m => m.Count(It.IsAny<Func<User, bool>>())).Returns(0);
            _mockUserRepository.Setup(m => m.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(user);
            _mockUserRepository.Setup(m => m.Update(user.Id.ToString(), user));
            //act
            _userDomain.ChangePassord(user.Id, user.Password);
            //Asert
            
        }

        [TestMethod]
        public void GivenUser_WhenUpdateUser_UserShouldBeUpdated()
        {
            //arrange
            var user = GetUser();
            _mockUserRepository.Setup(m => m.Count(It.IsAny<Func<User, bool>>())).Returns(1);

            _mockUserRepository.Setup(m => m.Update(user.Id.ToString(), user));
            //act
            _userDomain.Update(x=>x.Id==user.Id, user);
            //assert
            _mockUserRepository.Verify(x => x.Count(It.IsAny<Func<User, bool>>()), Times.AtMostOnce());
            _mockUserRepository.Verify(x => x.Update(user.Id.ToString(), user), Times.AtMostOnce());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GivenUserWithInvalidUser_WhenUpdateUser_UserShoulNotBeUpdated()
        {
            //arrange
            var user = GetUser();
            _mockUserRepository.Setup(m => m.Count(It.IsAny<Func<User, bool>>())).Returns(0);

            _mockUserRepository.Setup(m => m.Update(user.Id.ToString(), user));
            //act
            _userDomain.Update(x => x.Id == user.Id, user);
            //assert
            //_mockUserRepository.Verify(x => x.Count(It.IsAny<Func<User, bool>>()), Times.AtMostOnce());
            //_mockUserRepository.Verify(x => x.Update(user.Id.ToString(), user), Times.AtMostOnce());
        }

        [TestInitialize]
        public void Setup()
        {
            _mockUserRepository = new Mock<IRepository<User>>();
            _userDomain = new UserDomain(_mockUserRepository.Object);
        }

        private User GetUser()
        {
            return new User
            {
                Id = "1",
                Address = new Address
                {
                    CityId = 1,
                    StateId = 1,
                    currentAddress = "pune",
                    PinCode = 410014
                },
                FirstName = "test",
                MiddleName = "test2",
                UserName = "abc",
                Password="xyz"
            };
        }
    }
}
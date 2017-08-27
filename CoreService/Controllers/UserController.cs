using StudyMateLibrary.Enities;
using StudyMateLibrary.Domains;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreService.Controllers
{
    public class UserController : ApiController
    {
        private UserDomain _UserDomain;

        public UserController()
        {
            _UserDomain = new UserDomain();
        }

        //[HttpGet]
        //public User GetUser(int id)
        //{
        //    return _UserDomain.GetUser(x => x.UserId == id);
        //}

        [HttpGet]
        public User GetUserByUsername(string username)
        {
            return _UserDomain.Get(x => x.UserName == username);
        }

        public IEnumerable<User> ListUser()
        {
            return _UserDomain.List();
        }

        //[HttpPost]
        //public HttpResponseMessage AddUser(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        user.GuidId = new Guid();
        //     var result= _UserDomain.ad(user);
        //      return new HttpResponseMessage(HttpStatusCode.Created);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        [HttpPost]
        public HttpResponseMessage ChangePassword(User user)
        {
            var result = _UserDomain.ChangePassord(user.Id, user.Password);
            if (result)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

     
    }
}
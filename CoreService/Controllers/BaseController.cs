using StudyMateLibrary.Domains;
using StudyMateLibrary.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreService.Controllers
{
    public class BaseController<T> : ApiController where T :Entity,new()
    {
        private CommonDomain<T> _commonDomain;

        public BaseController()
        {
            _commonDomain = new CommonDomain<T>();
        }

        [HttpGet]
        public virtual IEnumerable<T> List()
        {
            return _commonDomain.List();
        }
        [HttpGet]
        public virtual T Get(string id)
        {
            return _commonDomain.Get(x => x.Id == id);
        }


        [HttpPost]
        public virtual HttpResponseMessage Add(T entity)
        {
            if (ModelState.IsValid)
            {
                var result = _commonDomain.Add(entity);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPost]
        public virtual HttpResponseMessage Update(T enitty)
        {
            if (ModelState.IsValid)
            {
                var result = _commonDomain.Update(q => q.Id == enitty.Id, enitty);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public virtual HttpResponseMessage Detete(T entity)
        {
           
                var result = _commonDomain.Delete(entity);
            if(result)
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

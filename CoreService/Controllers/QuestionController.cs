using StudyMateLibrary.Enities;
using StudyMateLibrary.Domains;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreService.Controllers
{
    public class QuestionController : BaseController<Question>
    {
        private QuestionDomain _questionDomain;
      

        public QuestionController()
        {
            _questionDomain = new QuestionDomain();
        }

        //[HttpGet]
        //public Question GetQuestion(int id)
        //{
        //    return _questionDomain.Get(x => x.Id == id);
        //}

        public IEnumerable<Question> ListQestionByTestId(int id)
        {
            return _questionDomain.List(Question=>Question.TestId==id);
        }

        //[HttpPost]
        //public HttpResponseMessage AddQuestion(Question question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _questionDomain.AddQuestion(question);
        //        return new HttpResponseMessage(HttpStatusCode.Created);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //[HttpPost]
        //public HttpResponseMessage UpdateQuestion(Question question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _questionDomain.Update(q => q.Id == question.Id, question);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}
    }
}
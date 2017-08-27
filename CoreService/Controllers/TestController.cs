using StudyMateLibrary.Enities;
using StudyMateLibrary.Domains;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreService.Controllers
{
    public class TestController : BaseController<Test>
    {
        //private TestDomain _testDomain;

        //public TestController()
        //{
        //    _testDomain = new TestDomain();
        //}

        //[HttpGet]
        //public Test GetTest(int id)
        //{
        //    return _testDomain.GetQuestion(x => x.TestId == id);
        //}

        //public IEnumerable<Test> List()
        //{
        //    return _testDomain.List();
        //}

        //[HttpGet]
        //public IEnumerable<Test> List(string categoryId)
        //{
        //    return _testDomain.List(t => t.TestCategory == categoryId);
        //}

        //[HttpPost]
        //public HttpResponseMessage AddQuestion(Test question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _testDomain.AddQuestion(question);
        //        return new HttpResponseMessage(HttpStatusCode.Created);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //[HttpPost]
        //public HttpResponseMessage UpdateQuestion(Test question)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _testDomain.UpdateQuestion(q => q.TestId == question.TestId, question);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //[HttpGet]
        //public HttpResponseMessage Detete(int id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = _testDomain.Delete(id);
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}
    }
}
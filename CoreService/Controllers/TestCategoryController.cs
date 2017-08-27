using StudyMateLibrary.Enities;
using StudyMateLibrary.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CoreService.Controllers
{
    public class TestCategoryController : BaseController<TestCategory>
    {
        //private CategoryDomain _testCategoryDomain;

        public TestCategoryController()
        {
            //_testCategoryDomain = new CategoryDomain();
        }

        [HttpGet]
        public override TestCategory Get(string id)
        {
            return base.Get(id);
        }

        [HttpPost]
        public override HttpResponseMessage Add(TestCategory entity)
        {
            return base.Add(entity);
        }

      

    }
}

using Newtonsoft.Json;
using StudyMateLibrary.FrameWork.CustomExceptions;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace CoreService.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.ActionContext.ModelState.Clear();
            var exeption = actionExecutedContext.Exception;
            if ((exeption).GetType() == typeof(ProhibitCascadeDeleteException))
            {
                var exp = (ProhibitCascadeDeleteException)exeption;
                string message = JsonConvert.SerializeObject(exp.ValidationResults);

                actionExecutedContext.ActionContext.ModelState.AddModelError("Error", message);
                actionExecutedContext.Response = new HttpRequestMessage().CreateErrorResponse(HttpStatusCode.BadRequest, actionExecutedContext.ActionContext.ModelState);
            };
        }

        //base.OnException(actionExecutedContext);
    }
}
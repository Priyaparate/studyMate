using CoreService.Filters;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CoreService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API configuration and services
            GlobalConfiguration.Configuration.Filters.Add(new ExceptionFilter());
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{Action}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
        }
    }
}
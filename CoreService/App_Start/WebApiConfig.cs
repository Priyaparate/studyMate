using StudyMateLibrary.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace CoreService
{
    public static class WebApiConfig
    {
        public static Dictionary<Type, List<Type>> entityDependancies = new Dictionary<Type, List<Type>>();
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

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

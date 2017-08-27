using StudyMateLibrary.FrameWork;
using System;
using System.Linq;
using System.Web.Http;

namespace CoreService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            LoadAssembly();
        }

        private void LoadAssembly()
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.FullName == "StudyMateLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            EntityManager.LoadAssembly(assembly);
        }
    }
}
using System.Web.Mvc;
using System.Web.Routing;
using Exam.UI.Infrastructure;

namespace Exam.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // оставляем только движок Razor
            vEngine.Init();
            // иверсия зависимостей Autofac
            IoC.Init();
        }
    }
}

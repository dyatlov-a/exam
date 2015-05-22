using System.Web.Mvc;
using Exam.UI.Infrastructure;

namespace Exam.UI.Controllers
{
    public class HomeController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
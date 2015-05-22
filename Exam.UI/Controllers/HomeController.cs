using System.Web.Mvc;
using Exam.UI.Infrastructure;

namespace Exam.UI.Controllers
{
    /// <summary>
    /// Контроллер домашней страницы
    /// </summary>
    public class HomeController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
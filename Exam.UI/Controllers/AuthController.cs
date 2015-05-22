using System.Web.Mvc;
using System.Web.Security;
using Exam.UI.Infrastructure;
using Exam.UI.Infrastructure.Services;
using Exam.UI.Resourses;
using Exam.UI.ViewModels;

namespace Exam.UI.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (_authService.ValidateUser(loginModel.UserName, loginModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(loginModel.UserName, loginModel.IsRemember);
                    return RedirectToAction("Index", "Todolist");
                }

                ModelState.AddModelError("", ErrorsRes.HasNotUser);
            }

            return View(loginModel);
        }

        [HttpGet]
        public RedirectToRouteResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
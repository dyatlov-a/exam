using System.Web.Mvc;
using System.Web.Security;
using Exam.UI.Infrastructure;
using Exam.UI.Infrastructure.Services;
using Exam.UI.Resourses;
using Exam.UI.ViewModels;

namespace Exam.UI.Controllers
{
    /// <summary>
    /// Контроллер аутентификации
    /// </summary>
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Отображение формы для аутентификации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View(new LoginViewModel());
        }

        /// <summary>
        /// Аутентификация пользователя
        /// </summary>
        /// <param name="loginModel">Форма аутентификации</param>
        /// <returns></returns>
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

        /// <summary>
        /// Выход пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public RedirectToRouteResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
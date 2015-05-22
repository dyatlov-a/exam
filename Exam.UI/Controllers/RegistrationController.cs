using System.Web.Mvc;
using Exam.DAL;
using Exam.UI.Infrastructure;
using Exam.UI.Infrastructure.Services;
using Exam.UI.Resourses;
using Exam.UI.ViewModels;

namespace Exam.UI.Controllers
{
    /// <summary>
    /// Контроллер регистрации
    /// </summary>
    public class RegistrationController: BaseController
    {
        private readonly IUnitOfWork _unit;
        private readonly IAuthService _authService;

        public RegistrationController(IUnitOfWork unit, IAuthService authService)
        {
            _unit = unit;
            _authService = authService;
        }

        /// <summary>
        /// Отображает форму регистрации
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View(new RegistrationViewModel());
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="registrationModel">Форма регистрации</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(RegistrationViewModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                if (_authService.GetUser(registrationModel.UserName) == null)
                {
                    var passwordSalt = _authService.GeneratePasswordSalt();
                    var passwordHash = _authService.CreatePasswordHash(registrationModel.Password, passwordSalt);

                    _authService.CreateUser(registrationModel.UserName, passwordHash, passwordSalt);
                    _unit.Commit();

                    return RedirectToAction("Index", "Auth");
                }
                else
                {
                    ModelState.AddModelError("", ErrorsRes.HasUser);
                }
            }

            return View(registrationModel);
        }
    }
}
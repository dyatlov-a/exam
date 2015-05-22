using System;
using System.Web.Mvc;
using Exam.UI.Infrastructure;
using Exam.UI.Infrastructure.Services;
using Exam.UI.ViewModels.Objs;

namespace Exam.UI.Controllers
{
    /// <summary>
    /// Контроллер списка задач
    /// </summary>
    [Authorize]
    public class TodolistController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly ITodolistService _todolistService;

        public TodolistController(ITodolistService todolistService, IAuthService authService)
        {
            _todolistService = todolistService;
            _authService = authService;
        }

        /// <summary>
        /// Отобразить список для пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Index()
        {
            var user = _authService.GetUser(User.Identity.Name);

            return View(_todolistService.List(user.Id));
        }

        /// <summary>
        /// Отметить задачу выполненой
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns></returns>
        [HttpGet]
        public bool Achieved(Guid id)
        {
            _todolistService.Achieved(id);
            return true;
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="topic">Наименование задачи</param>
        /// <param name="text">Описание</param>
        /// <returns></returns>
        [HttpPost]
        public PartialViewResult Add(string topic, string text)
        {
            var user = _authService.GetUser(User.Identity.Name);
            var id = _todolistService.Add(topic, text, user.Id);

            return PartialView("_taskDetails", new TaskViewModel
            {
                Id = id,
                Text = text,
                Topic = topic
            });
        }
    }
}
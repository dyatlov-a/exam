using System;
using System.Web.Mvc;
using Exam.UI.Infrastructure;
using Exam.UI.Infrastructure.Services;
using Exam.UI.ViewModels.Objs;

namespace Exam.UI.Controllers
{
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

        [HttpGet]
        public ViewResult Index()
        {
            var user = _authService.GetUser(User.Identity.Name);

            return View(_todolistService.List(user.Id));
        }

        [HttpGet]
        public bool Achieved(Guid id)
        {
            _todolistService.Achieved(id);
            return true;
        }

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
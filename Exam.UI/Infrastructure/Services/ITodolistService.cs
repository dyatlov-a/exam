using System;
using System.Collections.Generic;
using Exam.UI.ViewModels.Objs;

namespace Exam.UI.Infrastructure.Services
{
    public interface ITodolistService
    {
        IEnumerable<TaskViewModel> List(Guid userId);

        Guid Add(string topic, string text, Guid userId);

        void Achieved(Guid id);
    }
}
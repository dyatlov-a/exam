using System;
using System.Collections.Generic;
using Exam.UI.ViewModels.Objs;

namespace Exam.UI.Infrastructure.Services
{
    public interface IToDoService
    {
        void Add(string topic, string text, Guid userId);

        IEnumerable<ActiveViewModel> List(Guid userId);
    }
}
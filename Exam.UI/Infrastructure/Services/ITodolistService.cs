using System;
using System.Collections.Generic;
using Exam.UI.ViewModels.Objs;

namespace Exam.UI.Infrastructure.Services
{
    public interface ITodolistService
    {
        /// <summary>
        /// Получить список задач для пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Список задач</returns>
        IEnumerable<TaskViewModel> List(Guid userId);

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="topic">Наименование задачи</param>
        /// <param name="text">Описание</param>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns>Идентификатор задачи</returns>
        Guid Add(string topic, string text, Guid userId);

        /// <summary>
        /// Отметить задачу как выполненную
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        void Achieved(Guid id);
    }
}
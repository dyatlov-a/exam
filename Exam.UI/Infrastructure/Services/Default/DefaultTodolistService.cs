using System;
using System.Collections.Generic;
using System.Linq;
using Exam.DAL;
using Exam.DAL.Entities;
using Exam.UI.ViewModels.Objs;

namespace Exam.UI.Infrastructure.Services.Default
{
    public class DefaultTodolistService : ITodolistService
    {
        private IUnitOfWork _unit;
        private IRepository _repository;

        public DefaultTodolistService(IUnitOfWork unit, IRepository repository)
        {
            _unit = unit;
            _repository = repository;
        }

        public Guid Add(string topic, string text, Guid userId)
        {
            var active = new TaskEntity
            {
                Topic = topic,
                Text = text,
                UserId = userId
            };

            _repository.InsertOrUpdate(active);
            _unit.Commit();

            return active.Id;
        }

        public void Achieved(Guid id)
        {
            var active = _repository.GetById<TaskEntity>(id);
            active.Achieved = true;
            _repository.InsertOrUpdate(active);
            _unit.Commit();
        }

        public IEnumerable<TaskViewModel> List(Guid userId)
        {
            var dbList = _repository.Get<TaskEntity>()
                .Where(d => d.UserId == userId && !d.Achieved)
                .OrderByDescending(d => d.Created)
                .ToList();

            return dbList.Select(m => new TaskViewModel(m));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Exam.DAL;
using Exam.DAL.Entities;
using Exam.UI.ViewModels.Objs;

namespace Exam.UI.Infrastructure.Services.Default
{
    public class DefaultToDoService : IToDoService
    {
        private IUnitOfWork _unit;
        private IRepository _repository;

        public DefaultToDoService(IUnitOfWork unit, IRepository repository)
        {
            _unit = unit;
            _repository = repository;
        }

        public void Add(string topic, string text, Guid userId)
        {
            var active = new ActiveEntity
            {
                Topic = topic,
                Text = text,
                UserId = userId
            };

            _repository.InsertOrUpdate(active);
            _unit.Commit();
        }

        public IEnumerable<ActiveViewModel> List(Guid userId)
        {
            return _repository.Get<ActiveEntity>()
                .Where(d => d.UserId == userId)
                .Select(m => new ActiveViewModel(m));
        }
    }
}
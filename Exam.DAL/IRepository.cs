using System;
using System.Linq;
using Exam.DAL.Contracts;

namespace Exam.DAL
{
    public interface IRepository
    {
        IQueryable<TEntity> Get<TEntity>(string includeProperties = "") 
            where TEntity : Entity;

        TEntity GetById<TEntity>(Guid id, string includeProperties = "") 
            where TEntity : Entity;

        void InsertOrUpdate<TEntity>(TEntity obj) 
            where TEntity : Entity;

        void Delete<TEntity>(object id) 
            where TEntity : Entity;
    }
}

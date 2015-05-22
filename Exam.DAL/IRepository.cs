using System;
using System.Linq;
using Exam.DAL.Contracts;

namespace Exam.DAL
{
    /// <summary>
    /// Доступ к БД
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Получить список сущностей
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <returns>Список сущностей</returns>
        IQueryable<TEntity> Get<TEntity>() 
            where TEntity : Entity;

        /// <summary>
        /// Получить одну сущность
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="id">Идентификатор</param>
        /// <returns>Сущность</returns>
        TEntity GetById<TEntity>(Guid id) 
            where TEntity : Entity;

        /// <summary>
        /// Создать или обновить сущность
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="obj">Сущность</param>
        void InsertOrUpdate<TEntity>(TEntity obj) 
            where TEntity : Entity;

        /// <summary>
        /// Удалить сущность
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="id">Идентификатор</param>
        void Delete<TEntity>(object id) 
            where TEntity : Entity;
    }
}

﻿using System;
using System.Data.Entity;
using System.Linq;
using Exam.DAL;
using Exam.DAL.Contracts;

namespace Exam.EF
{
    public class Repository : IRepository
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Get<TEntity>(string includeProperties = "") 
            where TEntity : Entity
        {
            var query = _context.Set<TEntity>()
                .AsQueryable();

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public TEntity GetById<TEntity>(Guid id, string includeProperties = "") 
            where TEntity : Entity
        {
            var query = _context.Set<TEntity>()
                .AsQueryable();

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.FirstOrDefault(d => d.Id == id);
        }

        public void InsertOrUpdate<TEntity>(TEntity obj) 
            where TEntity : Entity
        {
            var date = DateTime.Now;

            if (!obj.IsSave)
            {
                obj.Created = date;

                _context.Set<TEntity>()
                    .Add(obj);
            }
            else
            {
                obj.Modified = date;

                _context.Set<TEntity>().Attach(obj);
                _context.Entry(obj).State = EntityState.Modified;
            }
        }

        public void Delete<TEntity>(object id) 
            where TEntity : Entity
        {
            TEntity obj = _context.Set<TEntity>().Find(id);
            Delete(obj);
        }

        private void Delete<TEntity>(TEntity obj)
            where TEntity : Entity
        {
            if (_context.Entry(obj).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(obj);
            }
            _context.Set<TEntity>().Remove(obj);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TBS.Persistence;

namespace TBS.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext entities = null;
        DbSet<T> _objectSet;

        public GenericRepository(DbContext _entities)
        {
            entities = _entities;
            _objectSet = entities.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _objectSet.Where(predicate);
            }
            return _objectSet;
        }

        public T Get(Func<T, bool> predicate)
        {
            return _objectSet.First(predicate);
        }

        public void Add(T entity)
        {
            _objectSet.Add(entity);
        }

        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            _objectSet.Remove(entity);
        }

        public Task SaveChanges(T entity)
        {
            return null;
        }

    }
}

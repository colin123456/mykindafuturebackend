using Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Common;

namespace Persistence.Shared
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly StarshipDbContext _dbContext;

        public Repository(StarshipDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Set<T>().Add((entity));
            //_dbContext.SaveChanges();
        }

        public void AddRange(List<T> entities)
        {
            throw new NotImplementedException();
        }

        public T Get(Guid Id)
        {
            return _dbContext.Set<T>()
                .Single(h => h.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        public IEnumerable<T> Search(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }
    }
}

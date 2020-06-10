using System;
using System.Collections.Generic;
using System.Text;

namespace Application.interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(Guid Id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Func<T, bool> predicate);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}

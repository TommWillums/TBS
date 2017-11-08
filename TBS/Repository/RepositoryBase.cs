using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Data;

namespace TBS.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetList(int id = -1);
        void Save(T entity);
        void Remove(T entity);
    }

    //public class RepositoryBase
    //{
    //}
}

using System;
using System.Collections.Generic;
using TBS.Data;

namespace TBS.Repository
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Save(T entity);
    }

    public class RepositoryBase
    {
        private readonly ICQHandler _cqhandler;
        protected ICQHandler CQHandler => _cqhandler;

        protected RepositoryBase(UnitOfWork unitOfWork = null)
        {
            if (unitOfWork == null)
                _cqhandler = new CQHandler();
            else
                _cqhandler = new CQHandler(unitOfWork.Session);
        }

    }
}

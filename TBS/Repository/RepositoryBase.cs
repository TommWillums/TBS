using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Data;

namespace TBS.Repository
{
    public interface IRepository<T>
    {
        ISession Session { get; }

        T Get(int id);
        IEnumerable<T> GetList(int id = -1);
        void Save(T entity);
        void Remove(T entity);
        void JoinUnitOfWork(IUnitOfWork uow, bool saveUncommitted = true);
    }

    public class RepositoryBase
    {
        private ICQHandler _cqhandler;
        public ICQHandler CQHandler => _cqhandler;
        public ISession Session => _cqhandler.Session;

        protected RepositoryBase(ICQHandler cqhandler)
        {
            _cqhandler = cqhandler;
        }

        public void JoinUnitOfWork(IUnitOfWork uow, bool saveUncommitted = true)
        {
            if (saveUncommitted && _cqhandler.Session != uow.Session)
                _cqhandler.Session.Commit();

            _cqhandler.Session = uow.Session;
        }

    }
}

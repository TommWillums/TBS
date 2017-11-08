using System;

namespace TBS.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        ISession Session { get; set; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        ISession _session;
        public ISession Session { get { return _session; } set { _session = value; } }

        public UnitOfWork(ISession session)
        {
            _session = session;
            _session.BeginTransaction();
        }

        public void Commit()
        {
            _session.Commit();
        }

        public void Rollback()
        {
            _session.Rollback();
        }

    }
}

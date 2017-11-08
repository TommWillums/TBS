using System;

namespace TBS.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void Dispose();
        ISession Session { get; set; }
    }

    // Call BeginTransaction and set _UseTransaction = true 
    public class UnitOfWork : IUnitOfWork, IDisposable
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

        public void Dispose()
        {
            _session.Commit();
        }
    }
}

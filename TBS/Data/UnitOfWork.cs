using System;

namespace TBS.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void Dispose();
        ISession Session { get; set; }
        bool AutoCommit { get; set; }
    }

    // Implicit BeginTransaction with AutoCommit true
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        ISession _session;
        public ISession Session { get { return _session; } set { _session = value; } }
        public bool AutoCommit { get; set; }

        public UnitOfWork(ISession session)
        {
            _session = session;
            AutoCommit = true;
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
            if (AutoCommit)
                _session.Commit();
            else
                _session.Rollback();
        }
    }
}

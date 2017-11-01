using System;

namespace TBS.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        void Dispose();
    }

    // Implicit BeginTransaction with AutoCommit true
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        Session _session;
        public Session Session => _session;
        public bool AutoCommit { get; set; }

        public UnitOfWork(string connectionString = null)
        {
            AutoCommit = true;
            if (String.IsNullOrWhiteSpace(connectionString))
                _session = new Session(Util.AppSettings.DefaultDatabaseConnection);
            else
                _session = new Session(connectionString);
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

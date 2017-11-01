using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TBS.Data;

namespace TBS.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }

    // Implicit BeginTransaction - All entities join the same transaction
    // All repositories use the same session or the same database context
    public class UnitOfWork : IUnitOfWork
    {
        Session _session;
        public Session Session => _session;

        public UnitOfWork(string connectionString = null)
        {
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
    }
}

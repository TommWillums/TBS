using System;
using System.Data;
using System.Data.SqlClient;

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
        readonly IDbConnection _context;

        public IDbConnection Context => _context;
        public bool AutoCommit { get; set; }

        public UnitOfWork(string connectionString = null)
        {
            AutoCommit = true;
            if (String.IsNullOrWhiteSpace(connectionString))
                _context = new SqlConnection(Util.AppSettings.DefaultDatabaseConnection);
            else
                _context = new SqlConnection(connectionString);
        }

        public void Commit()
        {
//            _context.Commit();
        }

        public void Rollback()
        {
 //           _context.Rollback();
        }

        public void Dispose()
        {
   //         if (AutoCommit)
   //             _context.Commit();
   //         else
   //             _context.Rollback();
        }
    }
}

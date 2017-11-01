using System.Collections.Generic;
using TBS.Data.Dapper;

namespace TBS.Data
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
        void Commit();
        void Rollback();
    }

    public class Session : ISession
    {
        private readonly IDapperContext _context;

        public Session(string connectionString, bool useTransaction = true)
        {
            _context = new DapperContext(connectionString, useTransaction);
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _context.Query<T>(query, param);
        }

        public void Execute(string sql, object param)
        {
            _context.Execute(sql, param);
        }

        public void Commit()
        {
            _context.Commit();
        }

        public void Rollback()
        {
            _context.Rollback();
        }
    }
}
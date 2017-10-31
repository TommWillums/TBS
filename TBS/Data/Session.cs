using System.Collections.Generic;
using TBS.Data.Dapper;
using Dapper;

namespace TBS.Data
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
        //    void BeginTransaction();
        //    void Commit();
        //    void Rollback();
    }

    public class Session : ISession
    {
        private readonly IDapperContext _context;

        public Session(string connectionString)
        {
            _context = new DapperContext(connectionString);
        }

        public Session(IDapperContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Query<T>(query, param, transaction);
                return result;
            });
        }

        public void Execute(string sql, object param)
        {
            _context.Transaction(transaction => _context.Connection.Execute(sql, param, transaction));
        }

        //public void BeginTransaction()
        //{
        //    _context.BeginTransaction();
        //}

        //public void Commit()
        //{
        //    _context.Commit();
        //}

        //public void Rollback()
        //{
        //    _context.Rollback();
        //}

    }
}
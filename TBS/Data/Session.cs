//#if XXX
using System;
using System.Collections.Generic;
using TBS.Data.Dapper;

namespace TBS.Data
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, object param = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, object param = null);
        IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param = null);
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
            return _context.Query<T> (query, param);
        }

        public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string query, Func<TFirst, TSecond, TReturn> map, object param)
        {
            return _context.Query<TFirst, TSecond, TReturn>(query, map, param);
        }

        public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string query, Func<TFirst, TSecond, TThird, TReturn> map, object param)
        {
            return _context.Query<TFirst, TSecond, TThird, TReturn>(query, map, param);
        }
        public virtual IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string query, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, object param)
        {
            return _context.Query<TFirst, TSecond, TThird, TFourth, TReturn>(query, map, param);
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
//#endif
﻿using System.Collections.Generic;
using TBS.Data.Dapper;

namespace TBS.Data
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }

    public class Session : ISession
    {
        private readonly IDapperContext _context;

        public Session(IDapperContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _context.Query<T>(query, param);
        }

        public void Execute(string sql, object param)
        {
            _context.Execute(sql, param);
        }

        public void BeginTransaction()
        {
            _context.BeginTransaction();
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
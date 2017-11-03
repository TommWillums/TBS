using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TBS.Data.Dapper
{
    public interface IDapperContext : IDisposable
    {
        IDbConnection Connection { get; }
        void Execute(string query, object param);
        IEnumerable<T> Query<T>(string query, object param);

        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();
    }


    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        private IDbConnection   _connection;

        private readonly bool _useTransaction;
        private IDbTransaction  _transaction { get; set; }


        private DapperContext() { }

        public DapperContext(string connectionString, bool useTransaction)
        {
            _connectionString = connectionString;
            _useTransaction = useTransaction;
            BeginTransaction();
        }

        /// <summary>
        ///     Get the current connection, or open a new connection
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(_connectionString);

                if (string.IsNullOrWhiteSpace(_connection.ConnectionString))
                    _connection.ConnectionString = _connectionString;

                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                return _connection;
            }
        }

        public IEnumerable<T> Query<T>(string query, object param)
        {
            try
            {
                if (_useTransaction)
                    return Connection.Query<T>(query, param, _transaction);
                else
                    return Connection.Query<T>(query, param);
            }
            catch (SqlException)
            {
                Rollback();
                throw;
            }
        }

        public void Execute(string sql, object param)
        {
            try
            { 
            if (_useTransaction)
                Connection.Execute(sql, param, _transaction);
            else
                Connection.Execute(sql, param);
            }
            catch (SqlException)
            {
                Rollback();
                throw;
            }
        }

        /// <summary>
        ///     Start a new transaction if one is not already available
        /// </summary>
        public IDbTransaction BeginTransaction()
        {
            if (!_useTransaction)
                return null;
            if (_transaction == null || _transaction.Connection == null)
                _transaction = Connection.BeginTransaction();
            return _transaction;
        }

        /// <summary>
        ///     Commit, dispose and start a new transaction
        /// </summary>
        public void Commit()
        {
            if (_transaction == null)
                return;
            try
            {
                _transaction.Commit();
                _transaction.Dispose();
                BeginTransaction();
            }
            catch (Exception ex)
            {
                if (_transaction != null && _transaction.Connection != null)
                    Rollback();

                throw new NullReferenceException("Tried Commit on closed Transaction", ex);
            }
        }

        /// <summary>
        ///     Rollback, dispose and start a new transaction
        /// </summary>
        public void Rollback()
        {
            if (_transaction == null)
                return;
            try
            {
                _transaction.Rollback();
                _transaction.Dispose();
                BeginTransaction();
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Tried Rollback on closed Transaction", ex);
            }
        }

        /// <summary>
        ///     Dispose of the transaction and close the connection
        /// </summary>
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
                _connection = null;
            }
        }

    }
}

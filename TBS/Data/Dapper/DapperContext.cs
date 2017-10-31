﻿using System;
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

        //T Transaction<T>(Func<IDbTransaction, T> query);
        //IDbTransaction BeginTransaction();
        //void Commit();
        //void Rollback();
    }


    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;

        private IDbConnection   _connection;
        private IDbTransaction  _transaction { get; set; }

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
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
            return Connection.Query<T>(query, param);
        }

        public void Execute(string sql, object param)
        {
            Connection.Execute(sql, param);
        }

#if TRANS
        /// <summary>
        ///     Start a new transaction if one is not already available
        /// </summary>
        public IDbTransaction BeginTransaction()
        {
            if (_transaction == null || _transaction.Connection == null)
                _transaction = Connection.BeginTransaction();

            return _transaction;
        }

        /// <summary>
        /// </summary>
        public T Transaction<T>(Func<IDbTransaction, T> query)
        {
            if (_transaction == null)
            {
                return AutoTransaction(query);
            }
            else
            {
                return ExplicitTransaction(query);
            }
        }
        /// <summary>
        ///     Perform a transactionless query
        /// </summary>
        private T AutoTransaction<T>(Func<IDbTransaction, T> query)
        {
            using (var connection = Connection)
            {
                using (var transaction = BeginTransaction())
                {
                    try
                    {
                        var result = query(transaction);
                        transaction.Commit();
                        return result;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        ///     Perform a transactioned query
        /// </summary>
        private T ExplicitTransaction<T>(Func<IDbTransaction, T> query)
        {
            try
            {
                var result = query(_transaction);
                return result;
            }
            catch (Exception)
            {
                _transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        ///     Commit and dispose of the transaction
        /// </summary>
        public void Commit()
        {
            try
            {
                _transaction.Commit();
                _transaction.Dispose();
                _transaction = null;
            }
            catch (Exception ex)
            {
                if (_transaction != null && _transaction.Connection != null)
                    Rollback();

                throw new NullReferenceException("Tried Commit on closed Transaction", ex);
            }
        }

        /// <summary>
        ///     Rollback and dispose of the transaction
        /// </summary>
        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
                _transaction.Dispose();
                _transaction = null;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("Tried Rollback on closed Transaction", ex);
            }
        }
#endif

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

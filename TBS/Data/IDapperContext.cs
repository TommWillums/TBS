using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TBS.Persistence
{
    public interface IDapperContext : IDisposable
    {
        IDbConnection Connection { get; }
        /*
        T Transaction<T>(Func<IDbTransaction, T> query);
        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();
        */
    }
}

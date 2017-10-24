using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TBS.Persistence
{
    public class Database : IDatabase
    {
        readonly IDbConnection _db;

        public Database(IDbConnection db)
        {
            this._db = db;
        }

        public async Task<T> Query<T>(IQuery<T> query)
        {
            return await query.Execute(_db);
        }

        public void Execute(ICommand command)
        {
            command.Execute(_db);
        }
    }
}


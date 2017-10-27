using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBS.Data;

namespace TBS.Service
{
    public class ServiceBase
    {
        private readonly IDatabase _database;
        protected IDatabase Database => _database;

        protected ServiceBase(IDatabase database)
        {
            if (database == null)
                _database = new Database();
            else
                _database = database;
        }
    }
}

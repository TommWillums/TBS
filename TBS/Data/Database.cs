using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TBS.Data
{
    public interface IDatabase
    {
        Task<T> Query<T>(IQuery<T> query);
        void Execute(ICommand command);
    }

    public class Database : IDatabase
    {
        private ISession _session { get; set; }

        public Database(ISession session)
        {
            _session = session;
        }

        public async Task<T> Query<T>(IQuery<T> query)
        {
            return await query.Execute(_session);
        }

        public void Execute(ICommand command)
        {
            command.Execute(_session);
        }
    }
}


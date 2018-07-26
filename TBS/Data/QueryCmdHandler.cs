using System;

namespace TBS.Data
{
    public interface IQueryCmdHandler
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
        ISession GetSession();
    }

    public class QueryCmdHandler : IQueryCmdHandler
    {
        private ISession _session { get; set; }
        public ISession GetSession() { return _session; }

        public QueryCmdHandler()
        {
            _session = new Session(Util.AppSettings.DefaultDatabaseConnection, useTransaction: false);
        }

        public QueryCmdHandler(ISession session)
        {
            _session = session;
        }

        public T Query<T>(IQuery<T> query)
        {
            return query.Execute(_session);
        }

        public void Execute(ICommand command)
        {
            command.Execute(_session);
        }
    }
}


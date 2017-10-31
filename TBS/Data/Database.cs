using TBS.Data.Dapper;

namespace TBS.Data
{
    public interface IDatabase
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
        ISession GetSession();
    }

    public class Database : IDatabase
    {
        private ISession _session { get; set; }
        public ISession GetSession() { return _session; }

        public Database()
        {
            _session = new Session(Util.AppSettings.DefaultDatabaseConnection);
        }

        public Database(ISession session)
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


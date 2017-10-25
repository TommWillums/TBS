using TBS.Data.Dapper;

namespace TBS.Data
{
    public interface IDatabase
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
    }

    public class Database : IDatabase
    {
        private ISession _session { get; set; }

        //TODO: Get connection string from appsettings.json
        public static string DefaultConnectionString = "Server=.;Database=TBS;Integrated Security=True;";
        public static string TestDBConnectionString = "Server=.;Database=TBS;Integrated Security=True;";

        public Database()
        {
            _session = new Session(DefaultConnectionString);
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


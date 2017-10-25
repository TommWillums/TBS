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


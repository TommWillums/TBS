namespace TBS.Data
{
    public interface ICQHandler
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
        ISession GetSession();
    }

    public class CQHandler : ICQHandler
    {
        private ISession _session { get; set; }
        public ISession GetSession() { return _session; }

        public CQHandler()
        {
            _session = new Session(Util.AppSettings.DefaultDatabaseConnection);
        }

        public CQHandler(ISession session)
        {
            _session = session;
        }

        public T Query<T>(IQuery<T> query)
        {
            return query.Execute(_session);
        }

        public void Execute(ICommand command)
        {
            //command.Execute(_context);    // From DapperContext
            command.Execute(_session);
        }
    }
}


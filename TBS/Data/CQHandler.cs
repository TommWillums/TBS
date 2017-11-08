using System;

namespace TBS.Data
{
    public interface ICQHandler
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
        ISession Session { get; set; }
    }

    public class CQHandler : ICQHandler
    {
        public ISession Session { get; set; }

        public CQHandler(ISession session)
        {
            Session = session;
        }

        public T Query<T>(IQuery<T> query)
        {
            return query.Execute(Session);
        }

        public void Execute(ICommand command)
        {
            command.Execute(Session);
        }
    }
}

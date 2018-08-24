using System.Data;
using System.Data.SqlClient;

namespace TBS.Data
{
    public interface IQueryCmdHandler
    {
        T Query<T>(IQuery<T> query);
        void Execute(ICommand command);
    }

    public class QueryCmdHandler : IQueryCmdHandler
    {
        private IDbConnection _context { get; }

        public QueryCmdHandler()
        {
            _context = new SqlConnection(Util.AppSettings.DefaultDatabaseConnection);
        }

        public QueryCmdHandler(IDbConnection context)
        {
            _context = context;
        }

        public T Query<T>(IQuery<T> query)
        {
            return query.Execute(_context);
        }

        public void Execute(ICommand command)
        {
            command.Execute(_context);
        }
    }
}


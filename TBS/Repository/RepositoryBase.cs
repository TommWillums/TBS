using TBS.Data;

namespace TBS.Repository
{
    public class RepositoryBase
    {
        protected IQueryCmdHandler QueryCmdHandler { get; }

        protected RepositoryBase()
        {
            QueryCmdHandler = new QueryCmdHandler();
        }
    }
}

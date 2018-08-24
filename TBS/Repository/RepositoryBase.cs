using TBS.Data;

namespace TBS.Repository
{
    public class RepositoryBase
    {
        protected IQueryCmdHandler QueryCmdHandler { get; }

        protected RepositoryBase(UnitOfWork unitOfWork = null)
        {
            QueryCmdHandler = (unitOfWork == null) ? new QueryCmdHandler() : new QueryCmdHandler(unitOfWork.Context);
        }

    }
}

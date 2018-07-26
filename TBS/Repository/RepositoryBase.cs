using TBS.Data;

namespace TBS.Repository
{
    public class RepositoryBase
    {
        private readonly IQueryCmdHandler _cqhandler;
        protected IQueryCmdHandler QueryCmdHandler => _cqhandler;

        protected RepositoryBase(UnitOfWork unitOfWork = null)
        {
            if (unitOfWork == null)
                _cqhandler = new QueryCmdHandler();
            else
                _cqhandler = new QueryCmdHandler(unitOfWork.Session);
        }

    }
}

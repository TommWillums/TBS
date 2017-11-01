using TBS.Data;

namespace TBS.Repository
{
    public class RepositoryBase
    {
        private readonly ICQHandler _database;
        protected ICQHandler CQHandler => _database;

        protected RepositoryBase(ICQHandler database)
        {
            if (database == null)
                _database = new CQHandler();
            else
                _database = database;
        }
    }
}

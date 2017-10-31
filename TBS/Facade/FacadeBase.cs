using TBS.Data;

namespace TBS.Facade
{
    public class FacadeBase
    {
        private readonly ICQHandler _database;
        protected ICQHandler CQHandler => _database;

        protected FacadeBase(ICQHandler database)
        {
            if (database == null)
                _database = new CQHandler();
            else
                _database = database;
        }
    }
}

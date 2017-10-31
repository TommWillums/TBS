using TBS.Data;

namespace TBS.Facade
{
    public class FacadeBase
    {
        private readonly IDatabase _database;
        protected IDatabase Database => _database;

        protected FacadeBase(IDatabase database)
        {
            if (database == null)
                _database = new Database();
            else
                _database = database;
        }
    }
}

using TBS.Data;

namespace TBS.Service
{
    public class ServiceBase
    {
        private readonly IDatabase _database;
        protected IDatabase Database => _database;

        protected ServiceBase(IDatabase database)
        {
            if (database == null)
                _database = new Database();
            else
                _database = database;
        }

        public void BeginTransaction()
        {
            _database.GetSession().BeginTransaction();
        }

        public void Commit()
        {
            _database.GetSession().Commit();
        }

        public void Rollback()
        {
            _database.GetSession().Rollback();
        }
    }
}

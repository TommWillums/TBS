using System.Collections.Generic;

namespace TBS.Data
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
    //    void BeginTransaction();
    //    void Commit();
    //    void Rollback();
    }
}

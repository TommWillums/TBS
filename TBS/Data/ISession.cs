using System.Collections.Generic;
using System.Threading.Tasks;

namespace TBS.Data
{
    public interface ISession
    {
        IEnumerable<T> Query<T>(string query, object param = null);
        void Execute(string query, object param = null);
    }
}

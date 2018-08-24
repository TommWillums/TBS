using System.Data;

namespace TBS.Data
{
    public interface IQuery<T>
    {
        T Execute(IDbConnection conn);
    }
}

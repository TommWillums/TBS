using System.Data;

namespace TBS.Data
{
    public interface ICommand
    {
        void Execute(IDbConnection connection);
    }
}



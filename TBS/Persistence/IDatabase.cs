using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBS.Persistence
{
    public interface IDatabase
    {
        Task<T> Query<T>(IQuery<T> query);
        void Execute(ICommand command);
    }
}

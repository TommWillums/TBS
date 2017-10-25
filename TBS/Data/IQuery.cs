using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace TBS.Data
{
    public interface IQuery<T>
    {
        Task<T> Execute(ISession db);
    }
}

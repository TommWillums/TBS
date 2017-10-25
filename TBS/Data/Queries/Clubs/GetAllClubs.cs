using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBS.Domain;

namespace TBS.Data.Queries.Clubs
{
    public class GetAllClubs : IQuery<IList<Club>>
    {
        public IList<Club> Execute(ISession session)
        {
            return session.Query<Club>("select * from Clubs").ToList();
        }
    }
}

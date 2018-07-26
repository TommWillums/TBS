using System.Collections.Generic;
using System.Linq;
using TBS.Entities;

namespace TBS.Data.Queries.Clubs
{
    public class GetClubs : IQuery<IList<Club>>
    {
        public IList<Club> Execute(ISession session)
        {
            return session.Query<Club>("select * from Clubs").ToList();
        }
    }
}

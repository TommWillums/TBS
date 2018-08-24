using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TBS.Entities;

namespace TBS.Data.Queries.Users
{
    public class GetBookings : IQuery<IList<User>>
    {
        private readonly int _clubId;

        public GetBookings(int clubId)
        {
            _clubId = clubId;
        }

        public IList<User> Execute(IDbConnection session)
        {
            return session.Query<User>("select * from Users where ClubId = @Id", new { ID = _clubId }).ToList();
        }
    }

}

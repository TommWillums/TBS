using System.Collections.Generic;
using System.Linq;
using TBS.Domain;

namespace TBS.Data.Queries.Users
{
    public class GetUsersByClub : IQuery<IList<User>>
    {
        private readonly int _clubId;

        public GetUsersByClub(int clubId)
        {
            _clubId = clubId;
        }

        public IList<User> Execute(ISession session)
        {
            return session.Query<User>("select * from Users where ClubId = @Id", new { ID = _clubId }).ToList();
        }
    }

}

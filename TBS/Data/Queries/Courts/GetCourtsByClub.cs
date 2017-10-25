using System.Collections.Generic;
using System.Linq;
using TBS.Domain;

namespace TBS.Data.Queries.Courts
{
    public class GetClub : IQuery<IList<Court>>
    {
        private readonly int _clubId;

        public GetClub(int clubId)
        {
            _clubId = clubId;
        }

        public IList<Court> Execute(ISession session)
        {
            return session.Query<Court>("select * from Courts where ClubId = @Id").ToList();
        }
    }

}

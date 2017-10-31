using System.Linq;
using TBS.Domain;

namespace TBS.Data.Queries.Clubs
{
    public class GetClubQuery : IQuery<Club>
    {
        private readonly int _clubId;

        public GetClubQuery(int clubId)
        {
            _clubId = clubId;
        }

        public Club Execute(ISession session)
        {
            return session.Query<Club>("select * from Clubs where Id = @Id", new { Id = _clubId }).SingleOrDefault();
        }
    }

}

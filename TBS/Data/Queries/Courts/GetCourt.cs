using System.Linq;
using TBS.Entities;

namespace TBS.Data.Queries.Courts
{
    public class GetCourt : IQuery<Court>
    {
        private readonly int _courtId;

        public GetCourt(int courtId)
        {
            _courtId = courtId;
        }

        public Court Execute(ISession session)
        {
            return session.Query<Court>("select * from Courts where Id = @Id", new { Id = _courtId }).SingleOrDefault();
        }
    }

}

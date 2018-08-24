using System.Data;
using System.Linq;
using Dapper;
using TBS.Entities;

namespace TBS.Data.Queries.Clubs
{
    public class GetClub : IQuery<Club>
    {
        private readonly int _clubId;

        public GetClub(int clubId)
        {
            _clubId = clubId;
        }

        public Club Execute(IDbConnection conn)
        {
            return conn.QuerySingle<Club>("select * from Clubs where Id = @Id", new { Id = _clubId });
        }
    }

}

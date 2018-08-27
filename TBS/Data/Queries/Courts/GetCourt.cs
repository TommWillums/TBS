using System.Data;
using System.Linq;
using Dapper;
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

        public Court Execute(IDbConnection conn)
        {
            return conn.QuerySingleOrDefault<Court>("select * from Courts where Id = @Id", new { Id = _courtId });
        }
    }

}

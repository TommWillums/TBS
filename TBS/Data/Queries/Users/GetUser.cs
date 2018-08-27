using System.Data;
using Dapper;
using TBS.Entities;

namespace TBS.Data.Queries.Users
{
    public class GetUser : IQuery<User>
    {
        private readonly int _id;

        public GetUser(int id)
        {
            _id = id;
        }

        public User Execute(IDbConnection conn)
        {
            return conn.QuerySingleOrDefault<User>("select * from Users where Id = @Id", new { Id = _id });
        }
    }

}

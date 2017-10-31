﻿using System.Linq;
using TBS.Domain;

namespace TBS.Data.Queries.Users
{
    public class GetUser : IQuery<User>
    {
        private readonly int _userId;

        public GetUser(int userId)
        {
            _userId = userId;
        }

        public User Execute(ISession session)
        {
            return session.Query<User>("select * from Users where Id = @Id", new { Id = _userId }).SingleOrDefault();
        }
    }

}
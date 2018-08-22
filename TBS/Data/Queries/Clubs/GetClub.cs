﻿using System.Linq;
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

        public Club Execute(ISession session)
        {
            return session.Query<Club>("select * from Clubs where Id = @Id", new { Id = _clubId }).SingleOrDefault();
        }
    }

}
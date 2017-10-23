using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TBS.Domain;
using TBS.Persistence;

namespace TBS.Repository
{
    public class ClubsQuery
    {
        public async Task<Club> Get(int id)
        {
            return await ClubsDb.Get(id);
        }

        public async Task<IQueryable<Club>> GetAll(Expression<Func<Club, bool>> predicate = null)
        {
            var p = predicate;
            return null;
        }

    }


    /*
    // Call Persistence layer
    // Use Expression<> and translate to SQL here before calling dapper?
    // Use multiple DTO's to construct DO aggregates where necessary
    // Push business logic to the DO's
    */
}

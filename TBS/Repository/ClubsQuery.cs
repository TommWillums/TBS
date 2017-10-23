using System;
using System.Collections.Generic;
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

        public async Task<List<Club>> GetAll()
        {
            return await ClubsDb.GetAll();
        }

    }

}

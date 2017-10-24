using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TBS.Domain;
using TBS.Persistence;

namespace TBS.Repository
{
    public class ClubsQuery : IQuery<Club>
    {
        int id;

        public ClubsQuery(int id)
        {
            this.id = id;
        }

        public async Task<Club> Execute(IDbConnection db)
        {
            return await ClubsDb.Get(id);
        }

        //public async Task<List<Club>> GetAll()
        //{
        //    return await ClubsDb.GetAll();
        //}
    }

}

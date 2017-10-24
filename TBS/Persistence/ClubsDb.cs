using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using TBS.Domain;
using TBS.Service;

namespace TBS.Persistence
{
    public class ClubsDb
    {
        public static async Task<Club> Get(int id)
        {
            Club club = null;

            using (DbConnection conn = My.ConnectionFactory())
            {
                try { 
                    await conn.OpenAsync();
                    club = await conn.QuerySingleOrDefaultAsync<Club>("select * from Clubs where Id = @Id", new { Id = id });
                }
                finally
                {
                    conn.Close();
                }
            }
            return club;
        }

        public static async Task<List<Club>> GetAll()
        {
            using (DbConnection conn = My.ConnectionFactory())
            {
                try
                {
                    await conn.OpenAsync();
                    var clubs = await conn.QueryAsync<Club>("select * from Clubs");
                    return clubs.AsList();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}

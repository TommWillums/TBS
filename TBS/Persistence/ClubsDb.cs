using Dapper;
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

    }
}

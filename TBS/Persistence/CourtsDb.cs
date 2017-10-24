using Dapper;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using TBS.Domain;
using TBS.Service;

namespace TBS.Persistence
{
    public class CourtsDb
    {
        public static async Task<List<Court>> GetAll(int clubId)
        {
            using (DbConnection conn = My.ConnectionFactory())
            {
                try
                { 
                    await conn.OpenAsync();
                    var courts = await conn.QueryAsync<Court>("select * from Courts where ClubId = @ClubId", new { ClubId = clubId });
                    return courts.AsList();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

    }
}

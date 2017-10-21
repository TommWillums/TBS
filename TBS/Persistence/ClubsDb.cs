using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using TBS.Domain;
using System.Data.SqlClient;

namespace TBS.Persistence
{
    public class ClubsDb
    {
        public async Task<Club> Get(int id)
        {
            Club club = null;

            using (SqlConnection conn = new SqlConnection("Server=.;Database=TBS;Integrated Security=True"))
            {
                try { 
                    conn.Open();
                    club = await conn.QuerySingleAsync<Club>("select * from Clubs where Id = @Id", new { Id = id });
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

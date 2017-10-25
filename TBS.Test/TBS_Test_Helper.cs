using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using TBS.Data;

namespace TBS.Test
{
    public class TBS_Test_Helper
    {
        public static void TestPrepareDBToAddClub()
        {
            using (DbConnection conn = new SqlConnection(Database.TestDBConnectionString))
            {
                conn.Open();
                conn.Execute("delete from Clubs where (Shortname = 'LA_TENIS') or (Deleted = 1)");
            }

        }

        public static void TestPrepareDBToDeleteClub()
        {
            using (DbConnection conn = new SqlConnection(Database.TestDBConnectionString))
            {
                conn.Open();
                conn.Execute("delete from Clubs where (Shortname = 'LA_TENIS')");
                conn.Execute("insert into Clubs (ClubName, ShortName, Contact) values ('Mijas Club de Tenis', 'LA_TENIS', 'José')");
            }

        }
    }

}

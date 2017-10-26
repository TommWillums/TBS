using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using TBS.Util;

namespace TBS.Test
{
    public class TBS_Test_Helper
    {
        public static void TestPrepareDBToAddClub()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Clubs_Tbl where (Shortname = 'LA_TENIS') or (Deleted = 1)");
            }

        }

        public static void TestPrepareDBToDeleteClub()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Clubs_Tbl where (Shortname = 'LA_TENIS')");
                conn.Execute("insert into Clubs_Tbl (ClubName, ShortName, Contact) values ('Mijas Club de Tenis', 'LA_TENIS', 'José')");
            }

        }
    }

}

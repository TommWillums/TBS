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
                conn.Execute("delete from Clubs_Tbl where Shortname like 'Mijas%'");
            }

        }

        public static void TestPrepareDBToUpdateClub()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Clubs_Tbl where Shortname like 'Mijas%'");
                conn.Execute("insert into Clubs_Tbl (ClubName, ShortName, Contact) values ('Mijas Club de Tenis', 'Mijas', 'José')");
            }
        }

        public static void TestPrepareDBToAddCourt()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Courts_Tbl where (ClubId = 100 and Name like 'Mijas%')");
            }
        }

        public static void TestPrepareDBToUpdateCourt()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Courts_Tbl where (ClubId = 100 and Name like 'Mijas%')");
                conn.Execute("insert into Courts_Tbl (Name, ClubId, Active) values ('Mijas', 100, 1)");
            }

        }

    }

}

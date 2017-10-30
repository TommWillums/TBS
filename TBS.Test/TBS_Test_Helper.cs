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
                conn.Execute("delete from Clubs_Tbl where Shortname like 'TBSX%'");
            }

        }

        public static void TestPrepareDBToUpdateClub()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Clubs_Tbl where Shortname like 'TBSX%'");
                conn.Execute("insert into Clubs_Tbl (ClubName, ShortName, Contact) values ('TBSX', 'TBSX', 'TBSX')");
            }
        }

        public static void TestPrepareDBToAddCourt()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Courts_Tbl where (ClubId = 100 and Name like 'TBSX%')");
            }
        }

        public static void TestPrepareDBToUpdateCourt()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Courts_Tbl where (ClubId = 100 and Name like 'TBSX%')");
                conn.Execute("insert into Courts_Tbl (Name, ClubId, Active) values ('TBSX', 100, 1)");
            }
        }

        public static void TestPrepareDBForUsers()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Users_Tbl where Name like 'TBSX%'");
            }
        }
    }

}

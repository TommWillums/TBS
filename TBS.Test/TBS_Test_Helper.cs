using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using TBS.Util;

namespace TBS.Test
{
    public class TBS_Test_Helper
    {
        public static void TestPrepareDBDeleteTestdata()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("delete from Users_Tbl where ClubId = 2");
                conn.Execute("delete from Courts_Tbl where ClubId = 2");
                conn.Execute("delete from Clubs_Tbl where Id = 2");
            }

        }

        public static void TestPrepareDBToAddClub()
        {
            TestPrepareDBDeleteTestdata();
        }

        public static void TestPrepareDBAddClub2()
        {
            TestPrepareDBDeleteTestdata();
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                conn.Execute("insert into Clubs_Tbl (Id, ClubName, ShortName, Contact, CustomerId) " +
                             "values (2, 'TBSX', 'TBSX', 'TBSX', 9999)");
            }
        }

        public static void TestPrepareDBToAddCourt()
        {
            TestPrepareDBDeleteTestdata();
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                TestPrepareDBAddClub2();
            }
        }

        public static void TestPrepareDBToUpdateCourt()
        {
            using (DbConnection conn = new SqlConnection(AppSettings.TestDatabaseConnection))
            {
                conn.Open();
                TestPrepareDBToAddCourt();
                conn.Execute("insert into Courts_Tbl (Name, ClubId) values ('TBSX', 2)");
            }
        }

        public static void TestPrepareDBForUsers()
        {
            TestPrepareDBDeleteTestdata();
            TestPrepareDBAddClub2();
        }
    }

}

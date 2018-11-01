using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using TBS.Data;
using TBS.Util;

namespace TBS.Test
{
    public class TBS_Test_Helper
    {
        public static void AddClub(ISession session)
        {
            session.Execute("insert into Clubs_Tbl (Id, ClubName, ShortName, Contact, CustomerId) " 
                             + "values (2, 'TBSX', 'TBSX', 'TBSX', 9999)");
        }

        public static void AddCourt(ISession session)
        {
            session.Execute("insert into Courts_Tbl (Name, ClubId) values ('TBSX', 2)");
        }

        public static void AddUser(ISession session)
        {
            session.Execute("insert into Users_Tbl (Name, ClubId) values ('TBSX', 2)");
        }



    }

}

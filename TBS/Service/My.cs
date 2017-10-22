using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace TBS.Service
{
    public static class My
    {
        public static Func<DbConnection> ConnectionFactory = () => new SqlConnection(ConnectionString.Connection);

        static My()
        {
        }

        public static class ConnectionString
        {
            public static string Connection = "Server=.;Database=TBS;Integrated Security=True;";
            //ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }

        public static class Database
        {

        }

    }
}

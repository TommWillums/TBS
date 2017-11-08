using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TBS.Util
{
    public class AppSettings
    {
        private static string _defaultDBConnection;
        private static string _testDBConnection;

        public static string DefaultDatabaseConnection
        {
            get
            {
                if (_defaultDBConnection == null)
                {
                    _defaultDBConnection = GetConnectionString("ConnectionStrings:DefaultConnection");
                }
                return _defaultDBConnection;
            }
        }

        public static string TestDatabaseConnection
        {
            get
            {
                if (_testDBConnection == null)
                {
                    _testDBConnection = GetConnectionString("ConnectionStrings:TestConnection");
                }
                return _testDBConnection;
            }
        }

        private static string GetConnectionString(string key)
        {
            const string configFile = "appsettings.json";
            string configPath = Directory.GetCurrentDirectory();
            string setting = "";

            var config = new ConfigurationBuilder()
                .SetBasePath(configPath)
                .AddJsonFile(configFile)
                .Build();

            setting = config[key];
            return setting;
        }
    }
}

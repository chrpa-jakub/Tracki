using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Npgsql;

namespace Tracki
{
    class DbTools
    {
        public void CheckDbExistence()
        {
            var tempPath = @"C:\Users\diahex\Projects\Tracki\config.cfg";
            var line = "";
            var dbCreated = false;
            using (var reader = new StreamReader(tempPath))
            {
                for (int i = 0; i < 2; i++)
                {
                    line = reader.ReadLine();
                }

                var pattern = @"db_created = '(.+)'";
                var regex = new Regex(pattern);
                var matches = regex.Matches(line);

                var dbExists = Convert.ToString((matches[0].Groups[1].Value));
                if (dbExists == "false")
                {
                    dbCreated = true;
                }
            }

            if (dbCreated == true)
            {
                DbCreate();
            }
        }

        public void DbCreate()
        {
            var configPath = @"C:\Users\diahex\Projects\Tracki\config.cfg";
            var file = "";
            using (var reader = new StreamReader(configPath))
            {
                while (!reader.EndOfStream)
                {
                    file += reader.ReadLine() + Environment.NewLine;
                }
            }

            var regexList = new List<string>();

            regexList.Add(@"db_host = '(.+)'");
            regexList.Add(@"db_port = '(.+)'");
            regexList.Add(@"db_serverName = '(.+)'");
            regexList.Add(@"db_serverUsername = '(.+)'");
            regexList.Add(@"db_serverPassword = '(.+)'");
            regexList.Add(@"db_databaseName = '(.+)'");

            var MatchList = regexMatcher(regexList, file);
            var dbHost = MatchList[0];
            var dbPort = MatchList[1];
            var dbServerName = MatchList[2];
            var dbServerUsername = MatchList[3];
            var dbServerPassword = MatchList[4];
            var dbDatabaseName = MatchList[5];
            
            var connString = $"Host={dbHost};Username={dbServerUsername};Password={dbServerPassword};Database={dbDatabaseName}";
            var sqlConn = new NpgsqlConnection(connString);

            sqlConn.Open();
            

            
            var dbQueryPath = @"C:\Users\diahex\Projects\Tracki\TrackiC#\Tracki\TrackiBackEnd\bin\Release\netcoreapp3.1\dbQuery.sql";
            var dbQuery = File.ReadAllText(dbQueryPath);
            var sqlCmd = new NpgsqlCommand(dbQuery, sqlConn);
            //sqlCmd.ExecuteNonQuery();
            var cfgContents = "";
            using (var reader = new StreamReader(configPath))
            {
                while (!reader.EndOfStream)
                {
                    
                    var line = reader.ReadLine();
                    //Console.WriteLine(line);
                    if (line == "db_created = 'false'")
                    {
                        line = "db_created = 'true'";
                    }
                    cfgContents += line + Environment.NewLine;
                }
            }

            File.WriteAllText(configPath, cfgContents);

        }

        public List<string> regexMatcher(List<string> regexList, string text)
        {
            var MatchList = new List<string>();
            foreach (var pattern in regexList)
            {
                var m = Regex.Match(text, pattern);
                MatchList.Add(m.Groups[1].Value);

            }
            return MatchList;
        }

    }
}

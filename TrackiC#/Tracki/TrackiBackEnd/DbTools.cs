using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Npgsql;
using TrackiBackEnd;

namespace Tracki
{
    class DbTools
    {
        public void CheckDbExistence()
        {
            if (DatabaseInfo.Exists == "false")
            {
                DbCreate();
            }
        }

        public void DbCreate()
        {
            var sqlConn = new NpgsqlConnection(DatabaseInfo.ConnString);
            sqlConn.Open();


            var dbQueryPath = "dbQuery.sql";
            var dbQuery = File.ReadAllText(dbQueryPath);
            var sqlCmd = new NpgsqlCommand(dbQuery, sqlConn); 
            /*
             * DB setup query, only execute once.
             *
             * sqlCmd.ExecuteNonQuery();
             */
            var cfgContents = "";
           using (var reader = new StreamReader("config.cfg"))
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

            File.WriteAllText("config.cfg", cfgContents);

        }

        public string PullFromConfig(string lookingFor)
        {
            return Regex.Match(DatabaseInfo.ConfigText, $"{lookingFor} = '(.+)'").Groups[1].Value;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using Tracki;

namespace TrackiBackEnd
{
    class DatabaseInfo
    {
        public static string Exists { get; set; }
        public static string Host { get; set; }
        public static string Port { get; set; }
        public static string ServerName { get; set; }
        public static string ServerUsername { get; set; }
        public static string ServerPassword { get; set; }
        public static string DatabaseName { get; set; }
        public static string ConnString { get; set; }
        public static string ConfigText { get; set; }

        public DatabaseInfo()
        {
            var tools = new DbTools();
            Exists = tools.PullFromConfig("db_created");
            Host = tools.PullFromConfig("db_host");
            Port = tools.PullFromConfig("db_port");
            ServerName = tools.PullFromConfig("db_serverName");
            ServerUsername = tools.PullFromConfig("db_serverUsername");
            ServerPassword = tools.PullFromConfig("db_serverPassword");
            DatabaseName = tools.PullFromConfig("db_databaseName");
            ConnString = $"Host={Host};Username={ServerUsername};Password={ServerPassword};Database={DatabaseName}";
            ConfigText = File.ReadAllText("config.cfg");
        }
    }
}

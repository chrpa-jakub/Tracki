using System;
using Tracki;

namespace TrackiBackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DatabaseInfo.ConfigText);
            Console.ReadKey();
            var tools = new DbTools();
            tools.CheckDbExistence();
        }
    }
}

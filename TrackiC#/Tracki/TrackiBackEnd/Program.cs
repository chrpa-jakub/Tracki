using System;
using Tracki;

namespace TrackiBackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            new DatabaseInfo(); // Init object constructor.
            var tools = new DbTools();
            tools.CheckDbExistence();
        }
    }
}

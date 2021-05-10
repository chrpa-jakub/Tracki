using System;
using Tracki;

namespace TrackiBackEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            var tools = new DbTools();
            tools.CheckDbExistence();
        }
    }
}

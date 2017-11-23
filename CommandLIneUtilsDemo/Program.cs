using System;

namespace CmdUtilsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var appBuilder = new AppBuilder();
            var app = appBuilder.BuildApp();
            app.Execute(args);
        }
    }
}

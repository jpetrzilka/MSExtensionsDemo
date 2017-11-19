using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

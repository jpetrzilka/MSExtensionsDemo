using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdUtilsTest
{
    class AppBuilder
    {
        public CommandLineApplication BuildApp()
        {
            var app = new CommandLineApplication();
            var cmdBuilder = new CommandsBuilder();
            app.Command("start", cmdBuilder.BuildStartCmd());
            return app;
        }
    }
}

using CmdUtilsTest.Commands;
using Microsoft.Extensions.CommandLineUtils;
using System;

namespace CmdUtilsTest
{
    class AppBuilder
    {
        CommandLineApplication app;

        public CommandLineApplication BuildApp()
        {
            app = new CommandLineApplication();
            app.Name = "CB4 shutdown tool";
            app.HelpOption("-?|--help");
            app.VersionOption("-v|--version", $"{app.Name} v1.0.0");

            RegisterCommands();

            app.OnExecute(() =>
            {
                app.ShowVersion();
                Console.WriteLine("Use -? or --help to display help info");
                return 0;
            });

            return app;
        }

        private void RegisterCommands()
        {
            RegisterCommand(new StartCommand());
            RegisterCommand(new StopCommand());
            RegisterCommand(new SelfDestructCommand());
        }

        void RegisterCommand(IConsoleCmd command)
        {
            app.Command(command.Name, command.Action);
        }
    }
}

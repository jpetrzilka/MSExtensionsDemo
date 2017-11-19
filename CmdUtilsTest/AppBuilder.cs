using CmdUtilsTest.Commands;
using Microsoft.Extensions.CommandLineUtils;

namespace CmdUtilsTest
{
    class AppBuilder
    {
        CommandLineApplication app;

        public CommandLineApplication BuildApp()
        {
            app = new CommandLineApplication();
            app.HelpOption("-?|--help");
            RegisterCommand(new StartCommand());
            return app;
        }

        void RegisterCommand(IConsoleCmd command)
        {
            app.Command(command.Name, command.Action);
        }
    }
}

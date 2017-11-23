using System;
using Microsoft.Extensions.CommandLineUtils;
using System.Threading;

namespace CmdUtilsTest.Commands
{
    class SelfDestructCommand : IConsoleCmd
    {
        public string Name => "selfdestruct";

        public string Description => "Do not use!!!";

        public Action<CommandLineApplication> Action =>
            cmd =>
            {
                cmd.HelpOption("-h|--help");

                cmd.OnExecute(() =>
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Identity confirmation needed");
                    Console.Write("Initiating rectal scan");

                    for(int i = 0; i < 30; i++)
                    { 
                        Console.Write(".");
                        Thread.Sleep(500);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("A je po srande.");
                    Console.ResetColor();
                    return 0;
                });
            };
    }
}

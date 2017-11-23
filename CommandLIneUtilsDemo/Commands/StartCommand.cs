using System;
using Microsoft.Extensions.CommandLineUtils;

namespace CmdUtilsTest.Commands
{
    class StartCommand : IConsoleCmd
    {
        public string Name => "start";

        public string Description => "Starts the system";

        public Action<CommandLineApplication> Action =>
            cmd =>
            {
                cmd.Description = Description;
                cmd.HelpOption("-?|--help");

                var serviceOpt = cmd.Option("-s|--services <services>",
                                            "services to start separated by comma",
                                            CommandOptionType.MultipleValue);
                var dryRunOpt  = cmd.Option("-d|--dryrun",
                                            "displays only steps that will be taken",
                                            CommandOptionType.NoValue);

                cmd.OnExecute(() =>
                {
                    Console.WriteLine("Starting services {0}",
                                      String.Join(", ", serviceOpt.Values));

                    if (!dryRunOpt.HasValue())
                        Console.WriteLine("Serivces started");

                    return 0;
                });
            };
    }
}

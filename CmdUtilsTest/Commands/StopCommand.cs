using System;
using Microsoft.Extensions.CommandLineUtils;

namespace CmdUtilsTest.Commands
{
    class StopCommand : IConsoleCmd
    {
        public String Name => "Stop";

        public String Description => "Stops the system";

        public Action<CommandLineApplication> Action =>
            new Action<CommandLineApplication>(cmd =>
            {
                cmd.Description = Description;
                cmd.HelpOption("-?|--help");

                var serviceOpt = cmd.Option("-s|--services <services>",
                                            "services to Stop separated by comma",
                                            CommandOptionType.MultipleValue);
                var dryRunOpt = cmd.Option("-d|--dryrun",
                                           "displays only steps that will be taken",
                                           CommandOptionType.NoValue);
                var forceOpt = cmd.Option("-f|--force",
                                          "Forces the system shutdown",
                                          CommandOptionType.NoValue);

                cmd.OnExecute(() =>
                {
                    Console.WriteLine("Stopping services {0}",
                                      String.Join(", ", serviceOpt.Values));

                    if (!dryRunOpt.HasValue())
                    {
                        Console.WriteLine("Serivces stopped{0}",
                                          forceOpt.HasValue() ? " by force" : String.Empty);
                    }

                    return 0;
                });
            });
    }
}

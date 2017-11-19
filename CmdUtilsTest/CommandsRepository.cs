using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdUtilsTest
{
    class CommandsBuilder 
    {
        public Action<CommandLineApplication> BuildStartCmd()
        {
            return new Action<CommandLineApplication>(cmd =>
            {
                var opt = cmd.Option("-s|--services <services>", String.Empty, CommandOptionType.MultipleValue);
                cmd.OnExecute(() =>
                {
                    Console.WriteLine("Ahoj " + String.Join(", ", opt.Values));
                    Console.ReadLine();
                    return 0;
                });
            });
        }
    }
}

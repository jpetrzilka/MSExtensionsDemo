using Microsoft.Extensions.CommandLineUtils;
using System;

namespace CmdUtilsTest.Commands
{
    public interface IConsoleCmd
    {
        string Name { get; }
        string Description { get; }
        Action<CommandLineApplication> Action { get; }
    }
}

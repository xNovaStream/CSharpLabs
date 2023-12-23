using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Builders.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.TextFormatters.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class MainProgram
{
    public static void Main()
    {
        ILogger logger = new ConsoleLogger();
        IWriter writer = new ConsoleWriter(new TextFormatter());
        var fileSystemContext = new FileSystemContext(new NullFileSystem(logger));

        while (true)
        {
            string[] args = Console.ReadLine()?.Split(' ') ?? throw new ArgumentNullException(nameof(args));
            CommandData commandData = new CommandDataBuilder(args).Build();
            new CommandBuilder(logger, writer, commandData).Build().Execute(fileSystemContext);
        }
    }
}
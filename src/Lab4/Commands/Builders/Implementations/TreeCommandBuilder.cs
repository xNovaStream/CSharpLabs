using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class TreeCommandBuilder : ICommandBuilder
{
    private readonly ILogger _logger;
    private readonly IWriter _writer;
    private readonly CommandData _commandData;

    public TreeCommandBuilder(ILogger logger, IWriter writer, CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(commandData);

        _logger = logger;
        _writer = writer;
        _commandData = commandData;
    }

    public ICommand Build()
    {
        if (_commandData.Parameters.Count == 1)
        {
            return new InvalidCommand(_logger, "Unknown command");
        }

        ICommandBuilder commandBuilder = _commandData.Parameters[1] switch
        {
            "goto" => new TreeGotoCommandBuilder(_logger, _commandData),
            "list" => new TreeListCommandBuilder(_logger, _writer, _commandData),
            _ => new UnknownCommandBuilder(_logger),
        };

        return commandBuilder.Build();
    }
}
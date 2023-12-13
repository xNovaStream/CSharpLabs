using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class CommandBuilder : ICommandBuilder
{
    private readonly CommandData _commandData;
    private readonly ILogger _logger;
    private readonly IWriter _writer;

    public CommandBuilder(ILogger logger, IWriter writer, CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(commandData);
        ArgumentNullException.ThrowIfNull(writer);

        _logger = logger;
        _writer = writer;
        _commandData = commandData;
    }

    public ICommand Build()
    {
        if (_commandData.Parameters.Count == 0)
        {
            return new InvalidCommand(_logger, "Empty command");
        }

        ICommandBuilder commandBuilder = _commandData.Parameters[0] switch
        {
            "connect" => new ConnectCommandBuilder(_logger, _commandData),
            "disconnect" => new DisconnectCommandBuilder(_logger, _commandData),
            "tree" => new TreeCommandBuilder(_logger, _writer, _commandData),
            "file" => new FileCommandBuilder(_logger, _writer, _commandData),
            "quit" => new QuitCommandBuilder(),
            _ => new UnknownCommandBuilder(_logger),
        };

        return commandBuilder.Build();
    }
}
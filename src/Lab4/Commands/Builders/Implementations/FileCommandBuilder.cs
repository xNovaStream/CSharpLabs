using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class FileCommandBuilder : ICommandBuilder
{
    private readonly CommandData _commandData;
    private readonly ILogger _logger;
    private readonly IWriter _writer;

    public FileCommandBuilder(ILogger logger, IWriter writer, CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(writer);
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
            "show" => new FileShowCommandBuilder(_logger, _writer, _commandData),
            "move" => new FileMoveCommandBuilder(_logger, _commandData),
            "copy" => new FileCopyCommandBuilder(_logger, _commandData),
            "delete" => new FileDeleteCommandBuilder(_logger, _commandData),
            "rename" => new FileRenameCommandBuilder(_logger, _commandData),
            _ => new UnknownCommandBuilder(_logger),
        };

        return commandBuilder.Build();
    }
}
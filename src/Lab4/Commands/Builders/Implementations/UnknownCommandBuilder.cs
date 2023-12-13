using System;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class UnknownCommandBuilder : ICommandBuilder
{
    private readonly ILogger _logger;

    public UnknownCommandBuilder(ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(logger);

        _logger = logger;
    }

    public ICommand Build() => new InvalidCommand(_logger, "Name of command is unknown");
}
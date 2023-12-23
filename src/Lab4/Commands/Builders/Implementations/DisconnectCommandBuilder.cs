using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Validators;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class DisconnectCommandBuilder : ICommandBuilder
{
    private const int ParameterCount = 1;
    private static readonly string[] RequiredOptions = Array.Empty<string>();
    private static readonly string[] PossibleOptions = Array.Empty<string>();

    private readonly ILogger _logger;
    private readonly CommandData _commandData;

    public DisconnectCommandBuilder(ILogger logger, CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(commandData);

        _logger = logger;
        _commandData = commandData;
    }

    public ICommand Build()
    {
        var validator = new CommandFormatValidator(
            _commandData,
            new CommandFormat(ParameterCount, RequiredOptions, PossibleOptions));

        if (!validator.IsValid())
        {
            return new InvalidCommand(_logger, "Invalid format of command");
        }

        return new DisconnectCommand(_logger);
    }
}
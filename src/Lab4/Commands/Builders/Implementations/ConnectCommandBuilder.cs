using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Validators;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class ConnectCommandBuilder : ICommandBuilder
{
    private const int AddressInd = 1;
    private const string Mode = "-m";

    private const int ParameterCount = 2;
    private static readonly string[] RequiredOptions = { Mode };
    private static readonly string[] PossibleOptions = Array.Empty<string>();

    private readonly ILogger _logger;
    private readonly CommandData _commandData;

    public ConnectCommandBuilder(ILogger logger, CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(commandData);
        ArgumentNullException.ThrowIfNull(logger);

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

        return _commandData.Options[Mode] switch
        {
            "local" => new LocalConnectCommand(_logger, _commandData.Parameters[AddressInd]),
            _ => new InvalidCommand(_logger, "Unknown connect mode"),
        };
    }
}
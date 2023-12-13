using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Validators;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class FileShowCommandBuilder : ICommandBuilder
{
    private const int PathInd = 1;
    private const string Mode = "-m";
    private const string DefaultMode = "console";

    private const int ParameterCount = 3;
    private static readonly string[] RequiredOptions = Array.Empty<string>();
    private static readonly string[] PossibleOptions = { Mode };

    private readonly CommandData _commandData;
    private readonly ILogger _logger;
    private readonly IWriter _writer;

    public FileShowCommandBuilder(ILogger logger, IWriter writer, CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(commandData);
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(writer);

        _logger = logger;
        _writer = writer;
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

        return _commandData.Options.GetValueOrDefault(Mode, DefaultMode) switch
        {
            "console" => new FileShowConsoleCommand(_writer, _commandData.Parameters[PathInd]),
            _ => new InvalidCommand(_logger, "Unknown show mode"),
        };
    }
}
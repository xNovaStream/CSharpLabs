using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Validators;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class TreeListCommandBuilder : ICommandBuilder
{
    private const string Depth = "-d";
    private const string DefaultDepth = "1";

    private const int ParameterCount = 2;
    private static readonly string[] RequiredOptions = Array.Empty<string>();
    private static readonly string[] PossibleOptions = { Depth };

    private readonly ILogger _logger;
    private readonly IWriter _writer;
    private readonly CommandData _commandData;

    public TreeListCommandBuilder(ILogger logger, IWriter writer, CommandData commandData)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(commandData);

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

        return new TreeListCommand(
            _writer,
            Convert.ToInt32(_commandData.Options.GetValueOrDefault(Depth, DefaultDepth), null));
    }
}
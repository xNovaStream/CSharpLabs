using System;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser;
using Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Validators;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class FileRenameCommandBuilder : ICommandBuilder
{
    private const int SourcePathInd = 1;
    private const int NameInd = 2;

    private const int ParameterCount = 4;
    private static readonly string[] RequiredOptions = Array.Empty<string>();
    private static readonly string[] PossibleOptions = Array.Empty<string>();

    private readonly CommandData _commandData;
    private readonly ILogger _logger;

    public FileRenameCommandBuilder(ILogger logger, CommandData commandData)
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

        return new FileRenameCommand(_commandData.Parameters[SourcePathInd], _commandData.Parameters[NameInd]);
    }
}
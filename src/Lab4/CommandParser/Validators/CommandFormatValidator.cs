using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Validators;

public class CommandFormatValidator
{
    private readonly CommandData _commandData;
    private readonly CommandFormat _commandFormat;

    public CommandFormatValidator(CommandData commandData, CommandFormat commandFormat)
    {
        ArgumentNullException.ThrowIfNull(commandData);
        ArgumentNullException.ThrowIfNull(commandFormat);

        _commandData = commandData;
        _commandFormat = commandFormat;
    }

    public bool IsValid()
    {
        if (_commandData.Parameters.Count != _commandFormat.ParameterCount)
        {
            return false;
        }

        if (_commandFormat.RequiredOptions.Any(requiredOption => !_commandData.Options.ContainsKey(requiredOption)))
        {
            return false;
        }

        if (_commandData.Options.Any(option => !_commandFormat.RequiredOptions.Contains(option.Key) &&
                                               !_commandFormat.PossibleOptions.Contains(option.Key)))
        {
            return false;
        }

        return true;
    }
}
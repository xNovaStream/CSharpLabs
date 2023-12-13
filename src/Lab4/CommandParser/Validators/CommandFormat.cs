using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Validators;

public class CommandFormat
{
    public CommandFormat(int parameterCount, IEnumerable<string> requiredOptions, IEnumerable<string> possibleOptions)
    {
        ArgumentNullException.ThrowIfNull(requiredOptions);
        ArgumentNullException.ThrowIfNull(possibleOptions);

        ParameterCount = parameterCount > 0 ? parameterCount : throw new InvalidParameterCountException();
        RequiredOptions = requiredOptions.ToList();
        PossibleOptions = possibleOptions.ToList();
    }

    public int ParameterCount { get; }
    public IReadOnlyList<string> RequiredOptions { get; }
    public IReadOnlyList<string> PossibleOptions { get; }
}
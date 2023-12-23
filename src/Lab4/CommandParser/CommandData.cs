using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser;

public class CommandData
{
    public CommandData(IReadOnlyList<string> parameters, IReadOnlyDictionary<string, string> options)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        ArgumentNullException.ThrowIfNull(options);

        Parameters = new List<string>(parameters);
        Options = new Dictionary<string, string>(options);
    }

    public IReadOnlyList<string> Parameters { get; }
    public IReadOnlyDictionary<string, string> Options { get; }
}
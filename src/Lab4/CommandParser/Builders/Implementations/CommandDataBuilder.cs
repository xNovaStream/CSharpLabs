using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Builders.Implementations;

public class CommandDataBuilder : ICommandDataBuilder
{
    private readonly List<string> _arguments;

    public CommandDataBuilder(params string[] arguments)
    {
        ArgumentNullException.ThrowIfNull(arguments);

        _arguments = arguments.ToList();
    }

    public CommandData Build()
    {
        var parameters = new List<string>();
        var options = new Dictionary<string, string>();
        using IEnumerator<string> enumerator = _arguments.GetEnumerator();

        while (enumerator.MoveNext() && enumerator.Current.First() != '-')
        {
            var parameterBuilder = new ParameterBuilder(enumerator);
            parameters.Add(parameterBuilder.Build());
        }

        if (enumerator.Current == null) return new CommandData(parameters, options);

        do
        {
            string option = enumerator.Current;
            string parameter;
            if (enumerator.MoveNext())
            {
                var parameterBuilder = new ParameterBuilder(enumerator);
                parameter = parameterBuilder.Build();
            }
            else
            {
                parameter = string.Empty;
            }

            options.Add(option, parameter);
        }
        while (enumerator.MoveNext());

        return new CommandData(parameters, options);
    }
}
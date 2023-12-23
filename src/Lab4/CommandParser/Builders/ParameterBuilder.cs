using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandParser.Builders;

public class ParameterBuilder
{
    private readonly IEnumerator<string> _enumerator;

    public ParameterBuilder(IEnumerator<string> enumerator)
    {
        ArgumentNullException.ThrowIfNull(enumerator);

        _enumerator = enumerator;
    }

    public string Build()
    {
        ArgumentNullException.ThrowIfNull(_enumerator.Current);
        if (_enumerator.Current.First() == '-') return string.Empty;

        return _enumerator.Current.First() != '"' ? BuildSingleParameter() : BuildMultipleParameter();
    }

    private string BuildSingleParameter()
    {
        return _enumerator.Current.Trim('"');
    }

    private string BuildMultipleParameter()
    {
        string parameter = _enumerator.Current;

        while (_enumerator.Current.Last() != '"' && _enumerator.MoveNext())
        {
            ArgumentNullException.ThrowIfNull(_enumerator.Current);
            parameter += _enumerator.Current;
        }

        return parameter.Trim('"');
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

public class Journey
{
    private readonly List<EnvironmentBase> _environments;

    public Journey(IEnumerable<EnvironmentBase> environments)
    {
        _environments = environments?.ToList() ?? throw new ArgumentNullException(nameof(environments));
    }

    public IReadOnlyList<EnvironmentBase> Environments => _environments;
}
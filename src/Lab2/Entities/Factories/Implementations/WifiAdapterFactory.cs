using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories.Implementations;

public class WifiAdapterFactory : ComponentFactory<WifiAdapter>
{
    public WifiAdapterFactory(IComponentRepository<WifiAdapter> repository)
        : base(repository)
    {
    }

    public override WifiAdapter Create(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return string.IsNullOrEmpty(name) ? new NullWifiAdapter() : base.Create(name);
    }

    public override IEnumerable<WifiAdapter> CreateMultiple(IEnumerable<string> names)
    {
        ArgumentNullException.ThrowIfNull(names);

        return names.Select(Create);
    }
}
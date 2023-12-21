using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories.Implementations;

public class VideoCardFactory : ComponentFactory<VideoCard>
{
    public VideoCardFactory(IComponentRepository<VideoCard> repository)
        : base(repository)
    {
    }

    public override VideoCard Create(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return string.IsNullOrEmpty(name) ? new NullVideoCard() : base.Create(name);
    }

    public override IEnumerable<VideoCard> CreateMultiple(IEnumerable<string> names)
    {
        ArgumentNullException.ThrowIfNull(names);

        return names.Select(Create);
    }
}
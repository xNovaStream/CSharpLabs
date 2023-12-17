using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories.Implementations;

public class ComponentFactory<TComponent> : IComponentFactory<TComponent>
    where TComponent : Component
{
    private readonly IComponentRepository<TComponent> _repository;

    public ComponentFactory(IComponentRepository<TComponent> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public virtual TComponent Create(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return _repository.GetComponent(name);
    }

    public virtual IEnumerable<TComponent> CreateMultiple(IEnumerable<string> names)
    {
        ArgumentNullException.ThrowIfNull(names);

        return names.Select(Create);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

public class Department<TComponent> : IComponentFactory<TComponent>
    where TComponent : Component
{
    private readonly Dictionary<string, TComponent> _componentsByName;

    public Department(IEnumerable<TComponent>? componentsByName = null)
    {
        try
        {
            _componentsByName = componentsByName?.ToDictionary(component => component.Name)
                                ?? new Dictionary<string, TComponent>();
        }
        catch (ArgumentException)
        {
            throw new InvalidComponentNameException();
        }
    }

    public IReadOnlyDictionary<string, TComponent> ComponentsByName => _componentsByName;

    public void AddComponent(TComponent component)
    {
        ArgumentNullException.ThrowIfNull(component);

        if (!_componentsByName.TryAdd(component.Name, component)) throw new InvalidComponentNameException();
    }

    public TComponent CreateComponent(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        if (_componentsByName.TryGetValue(name, out TComponent? component))
        {
            return component with { };
        }
        else
        {
            throw new InvalidComponentNameException();
        }
    }

    public IReadOnlyList<TComponent> CreateComponents(IEnumerable<string> names)
    {
        ArgumentNullException.ThrowIfNull(names);

        return names.Select(CreateComponent).ToList();
    }
}
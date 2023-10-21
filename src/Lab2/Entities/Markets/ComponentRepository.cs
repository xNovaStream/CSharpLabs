using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

public class ComponentRepository<TComponent> : IComponentRepository<TComponent>
    where TComponent : Component
{
    private readonly Dictionary<string, TComponent> _componentsByName;

    public ComponentRepository(IEnumerable<TComponent>? componentsByName = null)
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

    public void RemoveComponent(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        _componentsByName.Remove(name);
    }

    public TComponent GetComponent(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        if (_componentsByName.TryGetValue(name, out TComponent? component))
        {
            return component;
        }
        else
        {
            throw new InvalidComponentNameException();
        }
    }

    public IReadOnlyList<TComponent> GetComponents(IEnumerable<string> names)
    {
        ArgumentNullException.ThrowIfNull(names);

        return names.Select(GetComponent).ToList();
    }
}
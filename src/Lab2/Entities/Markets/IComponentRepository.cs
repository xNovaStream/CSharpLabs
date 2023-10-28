using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

public interface IComponentRepository<TComponent>
    where TComponent : Component
{
    public IReadOnlyDictionary<string, TComponent> ComponentsByName { get; }

    public void AddComponent(TComponent component);
    public void RemoveComponent(string name);
    TComponent GetComponent(string name);
    IReadOnlyList<TComponent> GetComponents(IEnumerable<string> names);
}
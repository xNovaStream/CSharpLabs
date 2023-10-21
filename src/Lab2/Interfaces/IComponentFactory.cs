using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IComponentFactory<out TComponent>
    where TComponent : Component
{
    TComponent CreateComponent(string name);
    IReadOnlyList<TComponent> CreateComponents(IEnumerable<string> names);
}
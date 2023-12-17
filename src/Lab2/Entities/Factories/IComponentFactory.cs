using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories;

public interface IComponentFactory<out TComponent>
    where TComponent : Component
{
    TComponent Create(string name);
    IEnumerable<TComponent> CreateMultiple(IEnumerable<string> names);
}
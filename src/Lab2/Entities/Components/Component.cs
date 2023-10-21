using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public abstract record Component(
    string Name)
{
    public string Name { get; init; } = Name ?? throw new ArgumentNullException(nameof(Name));
    public virtual bool Equals(Component? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode(StringComparison.Ordinal);
    }
}
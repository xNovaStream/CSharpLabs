using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public abstract record Component(
    string Name)
{
    public string Name { get; init; } = string.IsNullOrEmpty(Name) ? throw new InvalidNameException() : Name;
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
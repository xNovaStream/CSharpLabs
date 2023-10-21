using System;
using System.Collections.Generic;
using System.Numerics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record ComputerCase(
        string Name,
        Vector2 MaxVideoCardSize,
        IReadOnlyList<string> SupportedMotherboardFormFactors,
        Vector3 MaxCpuCoolingSystemSize)
    : Component(Name)
{
    public IReadOnlyList<string> SupportedMotherboardFormFactors { get; init; } =
        new List<string>(SupportedMotherboardFormFactors ??
                         throw new ArgumentNullException(nameof(SupportedMotherboardFormFactors)));

    public virtual bool Equals(ComputerCase? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
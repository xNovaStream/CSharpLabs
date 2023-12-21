using System;
using System.Collections.Generic;
using System.Numerics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record ComputerCase(
        string Name,
        Vector2 MaxVideoCardSize,
        IReadOnlyList<MotherboardFormFactor> SupportedMotherboardFormFactors,
        Vector3 MaxCpuCoolingSystemSize)
    : Component(Name)
{
    public IReadOnlyList<MotherboardFormFactor> SupportedMotherboardFormFactors { get; init; } =
        new List<MotherboardFormFactor>(SupportedMotherboardFormFactors ??
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
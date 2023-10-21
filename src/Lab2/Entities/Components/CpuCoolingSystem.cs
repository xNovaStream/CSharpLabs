using System;
using System.Collections.Generic;
using System.Numerics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record CpuCoolingSystem(
        string Name,
        Vector3 Size,
        IReadOnlyList<string> SupportedSockets,
        uint Tdp)
    : Component(Name)
{
    public IReadOnlyList<string> SupportedSockets { get; init; } =
        new List<string>(SupportedSockets ??
                         throw new ArgumentNullException(nameof(SupportedSockets)));

    public virtual bool Equals(CpuCoolingSystem? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Chipset(
    IReadOnlyList<uint> AvailableMemoryFrequencies,
    bool IsXmpSupported)
{
    public IReadOnlyList<uint> AvailableMemoryFrequencies { get; init; } = new List<uint>(AvailableMemoryFrequencies);

    public virtual bool Equals(Chipset? other)
    {
        if (other == null) return false;
        return AvailableMemoryFrequencies.SequenceEqual(other.AvailableMemoryFrequencies) &&
               IsXmpSupported == other.IsXmpSupported;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AvailableMemoryFrequencies, IsXmpSupported);
    }
}
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Chipset(
    IReadOnlyList<uint> AvailableMemoryFrequencies,
    bool IsXmpSupported)
{
    public IReadOnlyList<uint> AvailableMemoryFrequencies { get; init; } = new List<uint>(AvailableMemoryFrequencies);
}
using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Cpu(
        string Name,
        uint CoreFrequency,
        uint CoreCount,
        string Socket,
        bool HaveIntegratedVideoCore,
        IReadOnlyList<uint> SupportedMemoryFrequencies,
        uint Tdp,
        uint ConsumedPower)
    : Component(Name)
{
    public string Socket { get; init; } = Socket ?? throw new ArgumentNullException(nameof(Socket));
    public IReadOnlyList<uint> SupportedMemoryFrequencies { get; init; } =
        new List<uint>(SupportedMemoryFrequencies ??
                       throw new ArgumentNullException(nameof(SupportedMemoryFrequencies)));
}
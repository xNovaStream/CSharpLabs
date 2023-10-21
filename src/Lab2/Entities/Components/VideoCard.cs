using System.Numerics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record VideoCard(
        string Name,
        Vector2 Size,
        uint VideoMemory,
        uint PcieLinesCount,
        uint ChipFrequency,
        uint ConsumedPower)
    : Component(Name);
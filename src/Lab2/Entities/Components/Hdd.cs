namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Hdd(
        string Name,
        uint Capacity,
        uint SpindleRotationSpeed,
        uint ConsumedPower)
    : Drive(Name, ConnectionOption.Sata, Capacity, ConsumedPower);
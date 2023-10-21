namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Ssd(
        string Name,
        ConnectionOption ConnectionOption,
        uint Capacity,
        uint MaxOperatingSpeed,
        uint ConsumedPower)
    : Drive(Name, ConnectionOption, Capacity, ConsumedPower);
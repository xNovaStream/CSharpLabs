namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public abstract record Drive(
        string Name,
        ConnectionOption ConnectionOption,
        uint Capacity,
        uint ConsumedPower)
    : Component(Name);
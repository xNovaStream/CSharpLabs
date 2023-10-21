namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record PowerUnit(
        string Name,
        uint PeakLoad)
    : Component(Name);
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record NullVideoCard()
    : VideoCard(
        string.Empty,
        default,
        default,
        default,
        default,
        default);
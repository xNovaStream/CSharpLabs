namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record NullWifiAdapter()
    : WifiAdapter(
        string.Empty,
        string.Empty,
        default,
        default,
        default);
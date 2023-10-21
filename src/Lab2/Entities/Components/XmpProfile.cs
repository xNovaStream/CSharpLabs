using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record XmpProfile(
    string Timings,
    double Voltage,
    uint Frequency)
{
    public string Timings { get; init; } = Timings ??
                                            throw new ArgumentNullException(nameof(Timings));
}
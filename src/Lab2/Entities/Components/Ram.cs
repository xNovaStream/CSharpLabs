using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Ram(
        string Name,
        uint MemorySize,
        IReadOnlyDictionary<uint, double> VoltagesBySupportedFrequency,
        IReadOnlyList<XmpProfile> AvailableXmpProfiles,
        string FormFactor,
        uint DdrVersion,
        uint ConsumedPower)
    : Component(Name)
{
    public IReadOnlyDictionary<uint, double> VoltagesBySupportedFrequency { get; init; } =
        new Dictionary<uint, double>(VoltagesBySupportedFrequency ??
                                     throw new ArgumentNullException(nameof(VoltagesBySupportedFrequency)));
    public IReadOnlyList<XmpProfile> AvailableXmpProfiles { get; init; } =
        new List<XmpProfile>(AvailableXmpProfiles ??
                             throw new ArgumentNullException(nameof(AvailableXmpProfiles)));
    public string FormFactor { get; init; } = FormFactor ??
                                              throw new ArgumentNullException(nameof(FormFactor));
}
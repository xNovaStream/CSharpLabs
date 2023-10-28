using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Ram(
        string Name,
        uint MemorySize,
        IReadOnlyList<JedecPair> JedecPairs,
        IReadOnlyList<XmpProfile> AvailableXmpProfiles,
        RamFormFactor FormFactor,
        uint DdrVersion,
        uint ConsumedPower)
    : Component(Name)
{
    public IReadOnlyList<JedecPair> JedecPairs { get; init; } =
        new List<JedecPair>(JedecPairs ?? throw new ArgumentNullException(nameof(JedecPairs)));
    public IReadOnlyList<XmpProfile> AvailableXmpProfiles { get; init; } =
        new List<XmpProfile>(AvailableXmpProfiles ?? throw new ArgumentNullException(nameof(AvailableXmpProfiles)));
    public RamFormFactor FormFactor { get; init; } =
        FormFactor ?? throw new ArgumentNullException(nameof(FormFactor));

    public virtual bool Equals(Ram? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
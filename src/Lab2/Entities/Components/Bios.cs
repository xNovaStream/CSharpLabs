using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Bios(
    string Type,
    string Version,
    IReadOnlyList<Cpu> SupportedCpus)
{
    public string Type { get; init; } = string.IsNullOrEmpty(Type) ? throw new InvalidNameException() : Type;
    public string Version { get; init; } = string.IsNullOrEmpty(Version) ? throw new InvalidNameException() : Version;
    public IReadOnlyList<Cpu> SupportedCpus { get; init; } =
        new List<Cpu>(SupportedCpus ?? throw new ArgumentNullException(nameof(SupportedCpus)));

    public virtual bool Equals(Bios? other)
    {
        if (other == null) return false;
        return Type == other.Type && Version == other.Version && SupportedCpus.SequenceEqual(other.SupportedCpus);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Type, Version, SupportedCpus);
    }
}
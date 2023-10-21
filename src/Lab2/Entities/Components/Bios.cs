using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Bios(
    string Type,
    string Version,
    IReadOnlyList<string> SupportedCpus)
{
    public string Type { get; init; } = Type ?? throw new ArgumentNullException(nameof(Type));
    public string Version { get; init; } = Version ?? throw new ArgumentNullException(nameof(Version));
    public IReadOnlyList<string> SupportedCpus { get; init; } =
        new List<string>(SupportedCpus ?? throw new ArgumentNullException(nameof(SupportedCpus)));
}
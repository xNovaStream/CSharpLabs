using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public abstract record Component(
    string Name)
{
    public string Name { get; init; } = Name ?? throw new ArgumentNullException(nameof(Name));
}
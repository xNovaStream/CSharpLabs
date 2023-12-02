using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record RamFormFactor(
    string Type)
{
    public string Type { get; init; } = string.IsNullOrEmpty(Type) ? throw new InvalidNameException() : Type;
}
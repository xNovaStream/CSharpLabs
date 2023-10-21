using System.Numerics;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record VideoCard(
        string Name,
        Vector2 Size,
        uint VideoMemory,
        uint PcieLinesCount,
        uint ChipFrequency,
        uint ConsumedPower)
    : Component(Name)
{
    public virtual bool Equals(VideoCard? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
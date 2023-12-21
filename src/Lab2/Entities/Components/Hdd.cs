namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Hdd(
        string Name,
        uint Capacity,
        uint SpindleRotationSpeed,
        uint ConsumedPower)
    : Drive(Name, ConnectionOption.Sata, Capacity, ConsumedPower)
{
    public virtual bool Equals(Hdd? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
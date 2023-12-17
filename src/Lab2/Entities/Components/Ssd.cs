namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Ssd(
        string Name,
        ConnectionOption ConnectionOption,
        uint Capacity,
        uint MaxOperatingSpeed,
        uint ConsumedPower)
    : Drive(Name, ConnectionOption, Capacity, ConsumedPower)
{
    public virtual bool Equals(Ssd? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
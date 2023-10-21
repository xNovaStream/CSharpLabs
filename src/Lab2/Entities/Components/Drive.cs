namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public abstract record Drive(
        string Name,
        ConnectionOption ConnectionOption,
        uint Capacity,
        uint ConsumedPower)
    : Component(Name)
{
    public virtual bool Equals(Drive? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record PowerUnit(
        string Name,
        uint PeakLoad)
    : Component(Name)
{
    public virtual bool Equals(PowerUnit? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record NullVideoCard()
    : VideoCard(
        string.Empty,
        default,
        default,
        default,
        default,
        default)
{
    public virtual bool Equals(NullVideoCard? other)
    {
        return other != null;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
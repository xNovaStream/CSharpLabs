namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record NullWifiAdapter()
    : WifiAdapter(
        "Default",
        "0",
        default,
        default,
        default)
{
    public virtual bool Equals(NullWifiAdapter? other)
    {
        return other != null;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
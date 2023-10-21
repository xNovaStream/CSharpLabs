using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record WifiAdapter(
        string Name,
        string WifiStandardVersion,
        bool HaveBluetoothModule,
        uint PcieLinesCount,
        uint ConsumedPower)
    : Component(Name)
{
    public string WifiStandardVersion { get; init; } = WifiStandardVersion ??
                                                       throw new ArgumentNullException(nameof(WifiStandardVersion));

    public virtual bool Equals(WifiAdapter? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
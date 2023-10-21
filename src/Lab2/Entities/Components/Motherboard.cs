using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Motherboard(
        string Name,
        string CpuSocket,
        uint PcieLinesCount,
        uint SataPortsCount,
        Chipset Chipset,
        uint SupportedDdrStandard,
        uint RamSlotsCount,
        string FormFactor,
        Bios Bios,
        bool HaveWifiModule)
    : Component(Name)
{
    public string CpuSocket { get; init; } = CpuSocket ?? throw new ArgumentNullException(nameof(CpuSocket));
    public Chipset Chipset { get; init; } = Chipset ?? throw new ArgumentNullException(nameof(Chipset));
    public string FormFactor { get; init; } = FormFactor ?? throw new ArgumentNullException(nameof(FormFactor));
    public Bios Bios { get; init; } = Bios ?? throw new ArgumentNullException(nameof(Bios));

    public virtual bool Equals(Motherboard? other)
    {
        if (other == null) return false;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

public record Motherboard(
        string Name,
        Socket CpuSocket,
        uint PcieLinesCount,
        uint SataPortsCount,
        Chipset Chipset,
        uint SupportedDdrStandard,
        uint RamSlotsCount,
        MotherboardFormFactor FormFactor,
        Bios Bios,
        bool HaveWifiModule)
    : Component(Name)
{
    public Socket CpuSocket { get; init; } = CpuSocket ?? throw new ArgumentNullException(nameof(CpuSocket));
    public Chipset Chipset { get; init; } = Chipset ?? throw new ArgumentNullException(nameof(Chipset));
    public MotherboardFormFactor FormFactor { get; init; } =
        FormFactor ?? throw new ArgumentNullException(nameof(FormFactor));
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
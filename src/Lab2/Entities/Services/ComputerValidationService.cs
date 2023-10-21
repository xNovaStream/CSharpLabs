using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Services;

public class ComputerValidationService : IComputerValidationService
{
    private const double OverestimationConsumedPower = 1.2;

    public ValidationReport TryValidate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        var report = new ValidationReport();

        report.Add(TryCpuValidate(computer));
        report.Add(TryCpuCoolingSystemValidate(computer));
        report.Add(TryRamValidate(computer));
        report.Add(TryVideoCardValidate(computer));
        report.Add(TryCaseValidate(computer));
        report.Add(TryPowerUnitValidate(computer));
        report.Add(TryWifiAdapterValidate(computer));
        report.Add(TryPcieSataValidate(computer));

        return report;
    }

    private static ValidationReport TryCpuValidate(Computer computer)
    {
        var report = new ValidationReport();

        if (computer.Cpu.Socket != computer.Motherboard.CpuSocket)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: sockets on the motherboard and processor not compatible"));
        }

        if (!computer.Motherboard.Bios.SupportedCpus.Contains(computer.Cpu.Name))
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: cpu not supported by BIOS"));
        }

        return report;
    }

    private static ValidationReport TryCpuCoolingSystemValidate(Computer computer)
    {
        var report = new ValidationReport();

        if (!computer.CpuCoolingSystem.SupportedSockets.Contains(computer.Cpu.Socket))
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: cpu cooling system not supported cpu socket"));
        }

        if (computer.CpuCoolingSystem.Tdp < computer.Cpu.Tdp)
        {
            report.Add(new ValidationReport(
                haveWarranty: false,
                description: "Warning: cpu cooling system's TDP is too low"));
        }

        return report;
    }

    private static ValidationReport TryRamValidate(Computer computer)
    {
        var report = new ValidationReport();

        if (computer.Rams.Count > computer.Motherboard.RamSlotsCount)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: too many ram plates"));
        }

        foreach (Ram ram in computer.Rams)
        {
            if (ram.DdrVersion != computer.Motherboard.SupportedDdrStandard)
            {
                report.Add(new ValidationReport(
                    isValid: false,
                    description: "Fail: ram's DDR not supported by motherboard"));
            }

            if (ram.AvailableXmpProfiles.Count != 0 && !computer.Motherboard.Chipset.IsXmpSupported)
            {
                report.Add(new ValidationReport(
                    isValid: false,
                    description: "Fail: ram with XML Profile not supported by motherboard"));
            }

            if (!computer.Motherboard.Chipset.AvailableMemoryFrequencies.Any(frequency =>
                    ram.VoltagesBySupportedFrequency.ContainsKey(frequency)) &&
                !computer.Cpu.SupportedMemoryFrequencies.Any(frequency =>
                    ram.AvailableXmpProfiles.Any(xmpProfile => xmpProfile.Frequency == frequency)))
            {
                report.Add(new ValidationReport(
                    isValid: false,
                    description: "Fail: no available frequency"));
            }
        }

        return report;
    }

    private static ValidationReport TryVideoCardValidate(Computer computer)
    {
        var report = new ValidationReport();

        if (computer is { VideoCard: NullVideoCard, Cpu.HaveIntegratedVideoCore: false })
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: computer have no video card"));
        }

        return report;
    }

    private static ValidationReport TryCaseValidate(Computer computer)
    {
        var report = new ValidationReport();

        if (!computer.Case.SupportedMotherboardFormFactors.Contains(computer.Motherboard.FormFactor))
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: motherboard not fit into case"));
        }

        if (computer.Case.MaxCpuCoolingSystemSize.X < computer.CpuCoolingSystem.Size.X ||
            computer.Case.MaxCpuCoolingSystemSize.Y < computer.CpuCoolingSystem.Size.Y ||
            computer.Case.MaxCpuCoolingSystemSize.Z < computer.CpuCoolingSystem.Size.Z)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: cpu cooling system not fit into case"));
        }

        if (computer.Case.MaxVideoCardSize.X < computer.VideoCard.Size.X ||
            computer.Case.MaxVideoCardSize.Y < computer.VideoCard.Size.Y)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: video card not fit into case"));
        }

        return report;
    }

    private static ValidationReport TryPowerUnitValidate(Computer computer)
    {
        var report = new ValidationReport();

        uint sumConsumedPower = computer.Cpu.ConsumedPower + (uint)computer.Rams.Sum(ram => ram.ConsumedPower) +
                                  computer.VideoCard.ConsumedPower + computer.Drive.ConsumedPower +
                                  computer.WifiAdapter.ConsumedPower;
        if (computer.PowerUnit.PeakLoad < sumConsumedPower / OverestimationConsumedPower)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: power unit is too weak"));
        }

        if (computer.PowerUnit.PeakLoad < sumConsumedPower)
        {
            report.Add(new ValidationReport(
                description: "Warning: peak load less, then required"));
        }

        return report;
    }

    private static ValidationReport TryWifiAdapterValidate(Computer computer)
    {
        var report = new ValidationReport();

        if (computer.Motherboard.HaveWifiModule && computer.WifiAdapter is not NullWifiAdapter)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: network equipment conflict"));
        }

        if (!computer.Motherboard.HaveWifiModule && computer.WifiAdapter is NullWifiAdapter)
        {
            report.Add(new ValidationReport(
                description: "Warning: computer have no network equipment"));
        }

        return report;
    }

    private static ValidationReport TryPcieSataValidate(Computer computer)
    {
        var report = new ValidationReport();

        uint usedPcieLines = computer.VideoCard.PcieLinesCount + computer.WifiAdapter.PcieLinesCount;
        uint usedSataPorts = 0;
        switch (computer.Drive.ConnectionOption)
        {
            case ConnectionOption.Pcie:
                usedPcieLines += 1;
                break;
            case ConnectionOption.Sata:
                usedSataPorts += 1;
                break;
            default:
                throw new NotImplementedException();
        }

        if (usedSataPorts > computer.Motherboard.SataPortsCount)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: sata ports count not enough"));
        }

        if (usedPcieLines > computer.Motherboard.PcieLinesCount)
        {
            report.Add(new ValidationReport(
                isValid: false,
                description: "Fail: PCI-E lines count not enough"));
        }

        return report;
    }
}
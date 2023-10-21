using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Builders;

public record ComputerBuilder(
        string MotherboardName,
        string CpuName,
        string CpuCoolingSystemName,
        IReadOnlyList<string> RamNames,
        string DriveName,
        string ComputerCaseName,
        string PowerUnitName,
        string VideoCardName = "",
        string WifiAdapterName = "")
    : IComputerBuilder
{
    public ComputerBuilder(
        Computer computer)
    : this(
        computer?.Motherboard.Name ?? throw new ArgumentNullException(nameof(computer)),
        computer.Cpu.Name,
        computer.CpuCoolingSystem.Name,
        computer.Rams.Select(ram => ram.Name).ToList(),
        computer.VideoCard.Name,
        computer.Drive.Name,
        computer.Case.Name,
        computer.PowerUnit.Name,
        computer.WifiAdapter.Name)
    {
    }

    public string MotherboardName { get; init; } =
        MotherboardName ?? throw new ArgumentNullException(nameof(MotherboardName));
    public string CpuName { get; init; } =
        CpuName ?? throw new ArgumentNullException(nameof(CpuName));
    public string CpuCoolingSystemName { get; init; } =
        CpuCoolingSystemName ?? throw new ArgumentNullException(nameof(CpuCoolingSystemName));
    public IReadOnlyList<string> RamNames { get; init; } =
        new List<string>(RamNames ?? throw new ArgumentNullException(nameof(RamNames)));
    public string VideoCardName { get; init; } =
        VideoCardName ?? throw new ArgumentNullException(nameof(VideoCardName));
    public string DriveName { get; init; } =
        DriveName ?? throw new ArgumentNullException(nameof(DriveName));
    public string ComputerCaseName { get; init; } =
        ComputerCaseName ?? throw new ArgumentNullException(nameof(ComputerCaseName));
    public string PowerUnitName { get; init; } =
        PowerUnitName ?? throw new ArgumentNullException(nameof(PowerUnitName));
    public string WifiAdapterName { get; init; } =
        WifiAdapterName ?? throw new ArgumentNullException(nameof(WifiAdapterName));

    public Computer Build(
        IComponentsMarket market,
        IValidator computerValidator,
        out ValidationReport validationReport)
    {
        ArgumentNullException.ThrowIfNull(market);
        ArgumentNullException.ThrowIfNull(computerValidator);

        VideoCard videoCard = !string.IsNullOrEmpty(VideoCardName)
            ? market.VideoCardRepository.GetComponent(VideoCardName)
            : new NullVideoCard();
        WifiAdapter wifiAdapter = !string.IsNullOrEmpty(WifiAdapterName)
            ? market.WifiAdapterRepository.GetComponent(WifiAdapterName)
            : new NullWifiAdapter();
        var computer = new Computer(
            market.MotherboardRepository.GetComponent(MotherboardName),
            market.CpuRepository.GetComponent(CpuName),
            market.CpuCoolingSystemRepository.GetComponent(CpuCoolingSystemName),
            market.RamRepository.GetComponents(RamNames),
            videoCard,
            market.DriveRepository.GetComponent(DriveName),
            market.ComputerCaseRepository.GetComponent(ComputerCaseName),
            market.PowerUnitRepository.GetComponent(PowerUnitName),
            wifiAdapter);

        validationReport = computerValidator.Validate(computer);

        return computer;
    }
}
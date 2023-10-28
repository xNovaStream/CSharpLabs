using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories.Implementations;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

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

        var factories = new ComponentFactories(market);

        var computer = new Computer(
            factories.MotherboardFactory.Create(MotherboardName),
            factories.CpuFactory.Create(CpuName),
            factories.CpuCoolingSystemFactory.Create(CpuCoolingSystemName),
            factories.RamFactory.CreateMultiple(RamNames).ToList(),
            factories.VideoCardFactory.Create(VideoCardName),
            factories.DriveFactory.Create(DriveName),
            factories.ComputerCaseFactory.Create(ComputerCaseName),
            factories.PowerUnitFactory.Create(PowerUnitName),
            factories.WifiAdapterFactory.Create(WifiAdapterName));

        validationReport = computerValidator.Validate(computer);

        return computer;
    }
}
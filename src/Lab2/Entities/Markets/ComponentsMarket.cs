using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

public class ComponentsMarket : IComponentsMarket
{
    public ComponentsMarket(
        IEnumerable<Motherboard>? motherboards = null,
        IEnumerable<Cpu>? cpus = null,
        IEnumerable<CpuCoolingSystem>? cpuCoolingSystems = null,
        IEnumerable<Ram>? rams = null,
        IEnumerable<VideoCard>? videoCards = null,
        IEnumerable<Drive>? drive = null,
        IEnumerable<ComputerCase>? computerCases = null,
        IEnumerable<PowerUnit>? powerUnits = null,
        IEnumerable<WifiAdapter>? wifiAdapters = null)
    {
        MotherboardDepartment = new Department<Motherboard>(motherboards);
        CpuDepartment = new Department<Cpu>(cpus);
        CpuCoolingSystemDepartment = new Department<CpuCoolingSystem>(cpuCoolingSystems);
        RamDepartment = new Department<Ram>(rams);
        VideoCardDepartment = new Department<VideoCard>(videoCards);
        DriveDepartment = new Department<Drive>(drive);
        ComputerCaseDepartment = new Department<ComputerCase>(computerCases);
        PowerUnitDepartment = new Department<PowerUnit>(powerUnits);
        WifiAdapterDepartment = new Department<WifiAdapter>(wifiAdapters);
    }

    public Department<Motherboard> MotherboardDepartment { get; }
    public Department<Cpu> CpuDepartment { get; }
    public Department<CpuCoolingSystem> CpuCoolingSystemDepartment { get; }
    public Department<Ram> RamDepartment { get; }
    public Department<VideoCard> VideoCardDepartment { get; }
    public Department<Drive> DriveDepartment { get; }
    public Department<ComputerCase> ComputerCaseDepartment { get; }
    public Department<PowerUnit> PowerUnitDepartment { get; }
    public Department<WifiAdapter> WifiAdapterDepartment { get; }
}
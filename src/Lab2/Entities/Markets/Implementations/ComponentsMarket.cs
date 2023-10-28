using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets.Implementations;

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
        MotherboardRepository = new ComponentRepository<Motherboard>(motherboards);
        CpuRepository = new ComponentRepository<Cpu>(cpus);
        CpuCoolingSystemRepository = new ComponentRepository<CpuCoolingSystem>(cpuCoolingSystems);
        RamRepository = new ComponentRepository<Ram>(rams);
        VideoCardRepository = new ComponentRepository<VideoCard>(videoCards);
        DriveRepository = new ComponentRepository<Drive>(drive);
        ComputerCaseRepository = new ComponentRepository<ComputerCase>(computerCases);
        PowerUnitRepository = new ComponentRepository<PowerUnit>(powerUnits);
        WifiAdapterRepository = new ComponentRepository<WifiAdapter>(wifiAdapters);
    }

    public IComponentRepository<Motherboard> MotherboardRepository { get; }
    public IComponentRepository<Cpu> CpuRepository { get; }
    public IComponentRepository<CpuCoolingSystem> CpuCoolingSystemRepository { get; }
    public IComponentRepository<Ram> RamRepository { get; }
    public IComponentRepository<VideoCard> VideoCardRepository { get; }
    public IComponentRepository<Drive> DriveRepository { get; }
    public IComponentRepository<ComputerCase> ComputerCaseRepository { get; }
    public IComponentRepository<PowerUnit> PowerUnitRepository { get; }
    public IComponentRepository<WifiAdapter> WifiAdapterRepository { get; }
}
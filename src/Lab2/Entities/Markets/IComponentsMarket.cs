using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

public interface IComponentsMarket
{
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
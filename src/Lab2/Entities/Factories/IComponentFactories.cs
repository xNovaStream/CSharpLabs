using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories;

public interface IComponentFactories
{
    public IComponentFactory<Motherboard> MotherboardFactory { get; }
    public IComponentFactory<Cpu> CpuFactory { get; }
    public IComponentFactory<CpuCoolingSystem> CpuCoolingSystemFactory { get; }
    public IComponentFactory<Ram> RamFactory { get; }
    public IComponentFactory<VideoCard> VideoCardFactory { get; }
    public IComponentFactory<Drive> DriveFactory { get; }
    public IComponentFactory<ComputerCase> ComputerCaseFactory { get; }
    public IComponentFactory<PowerUnit> PowerUnitFactory { get; }
    public IComponentFactory<WifiAdapter> WifiAdapterFactory { get; }
}
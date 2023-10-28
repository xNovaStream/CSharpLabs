using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories.Implementations;

public class ComponentFactories : IComponentFactories
{
    public ComponentFactories(
        IComponentsMarket market)
    {
        ArgumentNullException.ThrowIfNull(market);

        MotherboardFactory = new ComponentFactory<Motherboard>(market.MotherboardRepository);
        CpuFactory = new ComponentFactory<Cpu>(market.CpuRepository);
        CpuCoolingSystemFactory = new ComponentFactory<CpuCoolingSystem>(market.CpuCoolingSystemRepository);
        RamFactory = new ComponentFactory<Ram>(market.RamRepository);
        VideoCardFactory = new VideoCardFactory(market.VideoCardRepository);
        DriveFactory = new ComponentFactory<Drive>(market.DriveRepository);
        ComputerCaseFactory = new ComponentFactory<ComputerCase>(market.ComputerCaseRepository);
        PowerUnitFactory = new ComponentFactory<PowerUnit>(market.PowerUnitRepository);
        WifiAdapterFactory = new WifiAdapterFactory(market.WifiAdapterRepository);
    }

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
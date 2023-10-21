using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Markets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

public interface IComponentsMarket
{
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
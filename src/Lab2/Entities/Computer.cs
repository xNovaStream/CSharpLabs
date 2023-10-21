using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public record Computer(
    Motherboard Motherboard,
    Cpu Cpu,
    CpuCoolingSystem CpuCoolingSystem,
    IReadOnlyList<Ram> Rams,
    VideoCard VideoCard,
    Drive Drive,
    ComputerCase Case,
    PowerUnit PowerUnit,
    WifiAdapter WifiAdapter)
{
    public Motherboard Motherboard { get; init; } = Motherboard ??
                                                    throw new ArgumentNullException(nameof(Motherboard));
    public Cpu Cpu { get; init; } = Cpu ??
                                    throw new ArgumentNullException(nameof(Cpu));
    public CpuCoolingSystem CpuCoolingSystem { get; init; } = CpuCoolingSystem ??
                                                              throw new ArgumentNullException(nameof(CpuCoolingSystem));
    public IReadOnlyList<Ram> Rams { get; init; } = new List<Ram>(Rams ??
                                                                  throw new ArgumentNullException(nameof(Rams)));
    public VideoCard VideoCard { get; init; } = VideoCard ??
                                                throw new ArgumentNullException(nameof(VideoCard));
    public Drive Drive { get; init; } = Drive ??
                                        throw new ArgumentNullException(nameof(Drive));
    public ComputerCase Case { get; init; } = Case ??
                                                      throw new ArgumentNullException(nameof(Case));
    public PowerUnit PowerUnit { get; init; } = PowerUnit ??
                                                throw new ArgumentNullException(nameof(PowerUnit));
    public WifiAdapter WifiAdapter { get; init; } = WifiAdapter ??
                                                    throw new ArgumentNullException(nameof(WifiAdapter));
}
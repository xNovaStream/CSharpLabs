using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public class ImpulseEngineClassE : ImpulseEngineBase
{
    private readonly double _speedBase;

    public ImpulseEngineClassE(double speedBase, double fuelConsumption, double startFuel)
        : base(fuelConsumption, startFuel)
    {
        _speedBase = speedBase > 1
            ? speedBase
            : throw new ArgumentException("Speed base must be greater than 1", nameof(speedBase));
    }

    protected override double GetSpentTime(double distance) =>
        Math.Log(distance * Math.Log(_speedBase), _speedBase);
}
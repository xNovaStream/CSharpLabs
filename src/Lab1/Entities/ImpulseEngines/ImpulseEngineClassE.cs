using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public class ImpulseEngineClassE : ImpulseEngineBase
{
    public ImpulseEngineClassE(double speedBase, double fuelConsumption, double startFuel)
        : base(fuelConsumption, startFuel)
    {
        SpeedBase = speedBase > 1
            ? speedBase
            : throw new ArgumentException("Speed base must be greater than 1", nameof(speedBase));
    }

    private double SpeedBase { get; }

    protected override double GetSpentTime(double distance) =>
        Math.Log(distance * Math.Log(SpeedBase), SpeedBase);
}
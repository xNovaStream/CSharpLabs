using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public class ImpulseEngineClassE : ImpulseEngineBase
{
    private readonly double _speedBase;

    public ImpulseEngineClassE(double speedBase, double fuelConsumption, double startFuel)
        : base(fuelConsumption, startFuel)
    {
        _speedBase = speedBase > 1 ? speedBase : throw new InvalidSpeedBaseException();
    }

    protected override double GetSpentTime(EnvironmentBase environment)
    {
        ArgumentNullException.ThrowIfNull(environment);

        return Math.Log(environment.Distance * Math.Log(_speedBase), _speedBase);
    }
}
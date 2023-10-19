using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public abstract class ImpulseEngineBase
{
    private readonly double _fuelConsumption;
    private readonly double _startFuel;

    protected ImpulseEngineBase(double fuelConsumption, double startFuel)
    {
        _fuelConsumption = fuelConsumption > 0 ? fuelConsumption : throw new InvalidFuelConsumptionException();
        _startFuel = startFuel > 0 ? startFuel : throw new InvalidStartFuelException();
    }

    public virtual FlightReport Move(EnvironmentBase environment)
    {
        ArgumentNullException.ThrowIfNull(environment);

        double spentTime = GetSpentTime(environment);
        double spentFuel = _startFuel + (_fuelConsumption * spentTime);

        return new FlightReport(FlightResult.Successful, spentFuel, spentTime);
    }

    protected abstract double GetSpentTime(EnvironmentBase environment);
}
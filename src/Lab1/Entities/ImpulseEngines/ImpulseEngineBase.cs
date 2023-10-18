using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public abstract class ImpulseEngineBase
{
    protected ImpulseEngineBase(double fuelConsumption, double startFuel)
    {
        FuelConsumption = fuelConsumption > 0
            ? fuelConsumption
            : throw new ArgumentException("Fuel consumption must be positive", nameof(fuelConsumption));
        StartFuel = startFuel > 0 ? startFuel
            : throw new ArgumentException("Fuel for start engine must be positive", nameof(startFuel));
    }

    private double FuelConsumption { get; }
    private double StartFuel { get; }

    public virtual FlightReport Move(EnvironmentBase environment)
    {
        ArgumentNullException.ThrowIfNull(environment);

        double spentTime = GetSpentTime(environment.Distance);
        double spentFuel = StartFuel + (FuelConsumption * spentTime);

        return new FlightReport(FlightResult.Successful, spentFuel, spentTime);
    }

    protected abstract double GetSpentTime(double distance);
}
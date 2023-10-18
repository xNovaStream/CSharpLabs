using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public abstract class JumpEngineBase
{
    protected JumpEngineBase(double maxDistance)
    {
        MaxDistance = maxDistance > 0
            ? maxDistance
            : throw new ArgumentException("Max distance must be positive", nameof(maxDistance));
    }

    private double MaxDistance { get; }

    // speed of all jump engine is equal, so time in subspace is equal to distance
    public FlightReport Move(HighDensityNebulae highDensityNebulae)
    {
        ArgumentNullException.ThrowIfNull(highDensityNebulae);

        return highDensityNebulae.Distance > MaxDistance
            ? new FlightReport(FlightResult.LostShip)
            : new FlightReport(
                FlightResult.Successful,
                GetSpentFuel(highDensityNebulae.Distance),
                highDensityNebulae.Distance);
    }

    protected abstract double GetSpentFuel(double distance);
}
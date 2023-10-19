using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public abstract class JumpEngineBase
{
    private readonly double _maxDistance;

    protected JumpEngineBase(double maxDistance)
    {
        _maxDistance = maxDistance >= 0
            ? maxDistance
            : throw new ArgumentException("Max distance must be positive", nameof(maxDistance));
    }

    public virtual FlightReport Move(HighDensityNebulae highDensityNebulae)
    {
        ArgumentNullException.ThrowIfNull(highDensityNebulae);

        return highDensityNebulae.Distance > _maxDistance
            ? new FlightReport(FlightResult.LostShip)
            : new FlightReport(
                FlightResult.Successful,
                GetSpentFuel(highDensityNebulae.Distance),
                highDensityNebulae.Distance);
    }

    protected abstract double GetSpentFuel(double distance);
}
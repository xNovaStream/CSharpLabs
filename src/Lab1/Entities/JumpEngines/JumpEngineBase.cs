using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public abstract class JumpEngineBase
{
    private readonly double _maxDistance;

    protected JumpEngineBase(double maxDistance)
    {
        _maxDistance = maxDistance >= 0
            ? maxDistance
            : throw new InvalidMaxSpeedException();
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
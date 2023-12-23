using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public class NullJumpEngine : JumpEngineBase
{
    public NullJumpEngine()
        : base(0)
    {
    }

    public override FlightReport Move(HighDensityNebulae highDensityNebulae) => new(FlightResult.ImpassableEnvironment);

    protected override double GetSpentFuel(double distance) => throw new NotSupportedException();
}
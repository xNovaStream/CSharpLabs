using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public class JumpEngineGamma : JumpEngineBase
{
    public JumpEngineGamma(double maxDistance)
        : base(maxDistance)
    {
    }

    protected override double GetSpentFuel(double distance) => Math.Pow(distance, 2);
}
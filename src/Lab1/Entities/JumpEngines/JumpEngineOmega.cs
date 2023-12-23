using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public class JumpEngineOmega : JumpEngineBase
{
    public JumpEngineOmega(double maxDistance)
        : base(maxDistance)
    {
    }

    protected override double GetSpentFuel(double distance) => distance * Math.Log(distance);
}
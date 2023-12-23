namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public class JumpEngineAlpha : JumpEngineBase
{
    public JumpEngineAlpha(double maxDistance)
        : base(maxDistance)
    {
    }

    protected override double GetSpentFuel(double distance) => distance;
}
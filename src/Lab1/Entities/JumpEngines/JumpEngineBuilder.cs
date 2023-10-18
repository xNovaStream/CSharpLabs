namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

public static class JumpEngineBuilder
{
    public static JumpEngineAlpha CreateAlpha() => new JumpEngineAlpha(10);
    public static JumpEngineOmega CreateOmega() => new JumpEngineOmega(50);
    public static JumpEngineGamma CreateGamma() => new JumpEngineGamma(100);
}
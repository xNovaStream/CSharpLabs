using Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

public interface IJumpEngineBuilder
{
    public NullJumpEngine CreateNull();
    public JumpEngineAlpha CreateAlpha();
    public JumpEngineOmega CreateOmega();
    public JumpEngineGamma CreateGamma();
}
using Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;

public class JumpEngineBuilder : IJumpEngineBuilder
{
    private const double AlphaMaxDistance = 10;
    private const double OmegaMaxDistance = 50;
    private const double GammaMaxDistance = 100;

    public NullJumpEngine CreateNull() => new NullJumpEngine();
    public JumpEngineAlpha CreateAlpha() => new JumpEngineAlpha(AlphaMaxDistance);
    public JumpEngineOmega CreateOmega() => new JumpEngineOmega(OmegaMaxDistance);
    public JumpEngineGamma CreateGamma() => new JumpEngineGamma(GammaMaxDistance);
}
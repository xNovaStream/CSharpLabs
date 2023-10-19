using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;

public class PhotonModifierBuilder : IPhotonModifierBuilder
{
    private const uint NullPhotonModifierHp = 0;
    private const uint PhotonModifierHp = 3;

    public PhotonModifier CreateNull() => new(NullPhotonModifierHp);
    public PhotonModifier Create() => new(PhotonModifierHp);
}
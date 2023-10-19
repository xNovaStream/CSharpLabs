using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

public interface IPhotonModifierBuilder
{
    public PhotonModifier CreateNull();
    public PhotonModifier Create();
}
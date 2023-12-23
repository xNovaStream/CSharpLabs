using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;

public class DeflectorBuilder : IDeflectorBuilder
{
    private const uint NullHp = 0;
    private const uint ClassOneHp = 10;
    private const uint ClassTwoHp = 25;
    private const uint ClassThreeHp = 50;

    private const uint NullDamageReduction = 0;
    private const uint ClassOneDamageReduction = 0;
    private const uint ClassTwoDamageReduction = 2;
    private const uint ClassThreeDamageReduction = 4;

    private readonly IPhotonModifierBuilder _photonModifierBuilder;

    public DeflectorBuilder(IPhotonModifierBuilder? photonModifierBuilder = null)
    {
        _photonModifierBuilder = photonModifierBuilder ?? new PhotonModifierBuilder();
    }

    public Deflector CreateNull() => new(
        NullHp,
        NullDamageReduction,
        _photonModifierBuilder.CreateNull());

    public Deflector CreateClassOne(bool isPhoton = false) => new(
        ClassOneHp,
        ClassOneDamageReduction,
        isPhoton ? _photonModifierBuilder.Create() : _photonModifierBuilder.CreateNull());

    public Deflector CreateClassTwo(bool isPhoton = false) => new(
        ClassTwoHp,
        ClassTwoDamageReduction,
        isPhoton ? _photonModifierBuilder.Create() : _photonModifierBuilder.CreateNull());

    public Deflector CreateClassThree(bool isPhoton = false) => new(
        ClassThreeHp,
        ClassThreeDamageReduction,
        isPhoton ? _photonModifierBuilder.Create() : _photonModifierBuilder.CreateNull());
}
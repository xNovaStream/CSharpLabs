using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;

public class ArmorBuilder : IArmorBuilder
{
    private const uint ClassOneHp = 5;
    private const uint ClassTwoHp = 15;
    private const uint ClassThreeHp = 25;

    private const int ClassOneDamageReduction = 0;
    private const int ClassTwoDamageReduction = 2;
    private const int ClassThreeDamageReduction = 4;

    public Armor CreateClassOne() => new(ClassOneHp, ClassOneDamageReduction);
    public Armor CreateClassTwo() => new(ClassTwoHp, ClassTwoDamageReduction);
    public Armor CreateClassThree() => new(ClassThreeHp, ClassThreeDamageReduction);
}
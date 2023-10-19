using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

public interface IArmorBuilder
{
    public Armor CreateClassOne();
    public Armor CreateClassTwo();
    public Armor CreateClassThree();
}
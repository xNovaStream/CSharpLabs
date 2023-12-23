using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

public interface IDeflectorBuilder
{
    public Deflector CreateNull();
    public Deflector CreateClassOne(bool isPhoton = false);
    public Deflector CreateClassTwo(bool isPhoton = false);
    public Deflector CreateClassThree(bool isPhoton = false);
}
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

public interface IImpulseEngineBuilder
{
    public ImpulseEngineClassC CreateClassC();
    public ImpulseEngineClassE CreateClassE();
}
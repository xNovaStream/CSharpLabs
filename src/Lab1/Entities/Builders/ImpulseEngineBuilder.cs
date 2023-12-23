using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;

public class ImpulseEngineBuilder : IImpulseEngineBuilder
{
    private const double Speed = 10;
    private const double SpeedBase = Math.E;

    private const double ClassCFuelConsumption = 1;
    private const double ClassEFuelConsumption = 10;

    private const double StartFuel = 10;

    public ImpulseEngineClassC CreateClassC() => new ImpulseEngineClassC(Speed, ClassCFuelConsumption, StartFuel);
    public ImpulseEngineClassE CreateClassE() => new ImpulseEngineClassE(SpeedBase, ClassEFuelConsumption, StartFuel);
}
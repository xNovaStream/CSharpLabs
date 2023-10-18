using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;

public static class ImpulseEngineBuilder
{
    public static ImpulseEngineClassC CreateClassC() => new ImpulseEngineClassC(10, 1, 10);
    public static ImpulseEngineClassE CreateClassE() => new ImpulseEngineClassE(Math.E, 10, 10);
}
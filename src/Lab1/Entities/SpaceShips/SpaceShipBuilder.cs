using Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public static class SpaceShipBuilder
{
    public static SpaceShip CreatePleasureShuttle() => new SpaceShip(
        ImpulseEngineBuilder.CreateClassC(),
        null,
        null,
        ProtectionBuilder.CreateArmorClass1(),
        false);

    public static SpaceShip CreateVaclas(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassE(),
        JumpEngineBuilder.CreateGamma(),
        ProtectionBuilder.CreateDeflectorClass1(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClass2(),
        false);

    public static SpaceShip CreateMeredian(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassE(),
        null,
        ProtectionBuilder.CreateDeflectorClass2(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClass2(),
        true);

    public static SpaceShip CreateStella(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassC(),
        JumpEngineBuilder.CreateOmega(),
        ProtectionBuilder.CreateDeflectorClass1(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClass1(),
        false);

    public static SpaceShip CreateAugur(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassE(),
        JumpEngineBuilder.CreateAlpha(),
        ProtectionBuilder.CreateDeflectorClass3(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClass3(),
        false);
}
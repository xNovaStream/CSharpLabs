using Itmo.ObjectOrientedProgramming.Lab1.Entities.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public static class SpaceShipBuilder
{
    public static SpaceShip CreatePleasureShuttle() => new SpaceShip(
        ImpulseEngineBuilder.CreateClassC(),
        JumpEngineBuilder.CreateNullJumpEngine(),
        ProtectionBuilder.CreateNullDeflector(),
        ProtectionBuilder.CreateArmorClassOne(),
        false);

    public static SpaceShip CreateVaclas(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassE(),
        JumpEngineBuilder.CreateGamma(),
        ProtectionBuilder.CreateDeflectorClassOne(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClassTwo(),
        false);

    public static SpaceShip CreateMeredian(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassE(),
        JumpEngineBuilder.CreateNullJumpEngine(),
        ProtectionBuilder.CreateDeflectorClassTwo(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClassTwo(),
        true);

    public static SpaceShip CreateStella(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassC(),
        JumpEngineBuilder.CreateOmega(),
        ProtectionBuilder.CreateDeflectorClassOne(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClassOne(),
        false);

    public static SpaceShip CreateAugur(bool isPhotonDeflector = false) => new SpaceShip(
        ImpulseEngineBuilder.CreateClassE(),
        JumpEngineBuilder.CreateAlpha(),
        ProtectionBuilder.CreateDeflectorClassThree(isPhotonDeflector),
        ProtectionBuilder.CreateArmorClassThree(),
        false);
}
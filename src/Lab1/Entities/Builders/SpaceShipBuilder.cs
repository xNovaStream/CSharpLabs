using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;

public class SpaceShipBuilder : ISpaceShipBuilder
{
    private readonly IImpulseEngineBuilder _impulseEngineBuilder;
    private readonly IJumpEngineBuilder _jumpEngineBuilder;
    private readonly IDeflectorBuilder _deflectorBuilder;
    private readonly IArmorBuilder _armorBuilder;

    public SpaceShipBuilder(
        IImpulseEngineBuilder? impulseEngineBuilder = null,
        IJumpEngineBuilder? jumpEngineBuilder = null,
        IDeflectorBuilder? deflectorBuilder = null,
        IArmorBuilder? armorBuilder = null)
    {
        _impulseEngineBuilder = impulseEngineBuilder ?? new ImpulseEngineBuilder();
        _jumpEngineBuilder = jumpEngineBuilder ?? new JumpEngineBuilder();
        _deflectorBuilder = deflectorBuilder ?? new DeflectorBuilder();
        _armorBuilder = armorBuilder ?? new ArmorBuilder();
    }

    public SpaceShip CreatePleasureShuttle() => new(
        _impulseEngineBuilder.CreateClassC(),
        _jumpEngineBuilder.CreateNull(),
        _deflectorBuilder.CreateNull(),
        _armorBuilder.CreateClassOne(),
        false);

    public SpaceShip CreateVaclas(bool isPhotonDeflector = false) => new(
        _impulseEngineBuilder.CreateClassE(),
        _jumpEngineBuilder.CreateGamma(),
        _deflectorBuilder.CreateClassOne(isPhotonDeflector),
        _armorBuilder.CreateClassTwo(),
        false);

    public SpaceShip CreateMeredian(bool isPhotonDeflector = false) => new(
        _impulseEngineBuilder.CreateClassE(),
        _jumpEngineBuilder.CreateNull(),
        _deflectorBuilder.CreateClassTwo(isPhotonDeflector),
        _armorBuilder.CreateClassTwo(),
        true);

    public SpaceShip CreateStella(bool isPhotonDeflector = false) => new(
        _impulseEngineBuilder.CreateClassC(),
        _jumpEngineBuilder.CreateOmega(),
        _deflectorBuilder.CreateClassOne(isPhotonDeflector),
        _armorBuilder.CreateClassOne(),
        false);

    public SpaceShip CreateAugur(bool isPhotonDeflector = false) => new(
        _impulseEngineBuilder.CreateClassE(),
        _jumpEngineBuilder.CreateAlpha(),
        _deflectorBuilder.CreateClassThree(isPhotonDeflector),
        _armorBuilder.CreateClassThree(),
        false);
}
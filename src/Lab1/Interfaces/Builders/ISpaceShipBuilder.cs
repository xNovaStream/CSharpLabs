using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

public interface ISpaceShipBuilder
{
    public SpaceShip CreatePleasureShuttle();
    public SpaceShip CreateVaclas(bool isPhotonDeflector = false);
    public SpaceShip CreateMeredian(bool isPhotonDeflector = false);
    public SpaceShip CreateStella(bool isPhotonDeflector = false);
    public SpaceShip CreateAugur(bool isPhotonDeflector = false);
}
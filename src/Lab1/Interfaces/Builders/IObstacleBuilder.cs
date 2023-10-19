using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

public interface IObstacleBuilder
{
    public Asteroid CreateSmallAsteroid();
    public Asteroid CreateMeteorite();
    public AntimatterFlare CreateAntimatterFlare();
    public SpaceWhale CreateSpaceWhale();
}
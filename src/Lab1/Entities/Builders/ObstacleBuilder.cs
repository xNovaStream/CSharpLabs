using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;

public class ObstacleBuilder : IObstacleBuilder
{
    private const uint SmallAsteroidDamage = 5;
    private const uint MeteoriteDamage = 10;
    private const uint SpaceWhaleDamage = 55;

    public Asteroid CreateSmallAsteroid() => new(SmallAsteroidDamage);
    public Asteroid CreateMeteorite() => new(MeteoriteDamage);
    public AntimatterFlare CreateAntimatterFlare() => new();
    public SpaceWhale CreateSpaceWhale() => new(SpaceWhaleDamage);
}
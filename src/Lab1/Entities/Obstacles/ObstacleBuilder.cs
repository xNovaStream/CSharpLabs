namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public static class ObstacleBuilder
{
    public static Asteroid CreateSmallAsteroid() => new Asteroid(5);
    public static Asteroid CreateMeteorite() => new Asteroid(10);
    public static AntimatterFlare CreateAntimatterFlare() => new AntimatterFlare();
    public static SpaceWhale CreateSpaceWhale() => new SpaceWhale(55);
}
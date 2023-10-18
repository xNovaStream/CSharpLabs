using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class ObstacleBase : IDamageDealer
{
    public abstract Damage Damage { get; }
}
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class AntimatterFlare : ObstacleBase
{
    public override Damage Damage => new(mental: true);
}
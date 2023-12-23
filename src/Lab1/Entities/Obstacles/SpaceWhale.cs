namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class SpaceWhale : ObstacleBase
{
    private readonly uint _damage;

    public SpaceWhale(uint damage)
    {
        _damage = damage;
    }

    public override Damage Damage => new(physic: _damage);
}
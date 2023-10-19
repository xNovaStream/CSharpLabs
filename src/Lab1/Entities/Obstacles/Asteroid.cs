namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public class Asteroid : ObstacleBase
{
    private readonly uint _damage;

    public Asteroid(uint damage)
    {
        _damage = damage;
    }

    public override Damage Damage => new(physic: _damage);
}
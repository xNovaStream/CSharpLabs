using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Space : EnvironmentBase
{
    public Space(double distance, IEnumerable<Asteroid>? asteroids = null)
        : base(distance, asteroids)
    {
    }
}
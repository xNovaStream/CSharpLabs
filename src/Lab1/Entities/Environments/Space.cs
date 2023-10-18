using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class Space : EnvironmentBase
{
    public Space(double distance, IEnumerable<Asteroid> obstacles)
        : base(distance, obstacles)
    {
    }

    public Space(double distance)
        : base(distance)
    {
    }
}
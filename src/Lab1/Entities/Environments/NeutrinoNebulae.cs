using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class NeutrinoNebulae : EnvironmentBase
{
    public NeutrinoNebulae(double distance, IEnumerable<SpaceWhale> obstacles)
        : base(distance, obstacles)
    {
    }

    public NeutrinoNebulae(double distance)
        : base(distance)
    {
    }
}
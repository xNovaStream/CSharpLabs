using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public class HighDensityNebulae : EnvironmentBase
{
    public HighDensityNebulae(double distance, IEnumerable<AntimatterFlare>? antimatterFlares = null)
        : base(distance, antimatterFlares)
    {
    }
}
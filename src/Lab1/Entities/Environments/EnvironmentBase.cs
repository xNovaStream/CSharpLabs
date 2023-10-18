using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class EnvironmentBase
{
    private readonly List<ObstacleBase> _obstacles;

    protected EnvironmentBase(double distance, IEnumerable<ObstacleBase> obstacles)
    {
        Distance = distance;
        _obstacles = obstacles?.ToList() ?? throw new ArgumentNullException(nameof(obstacles));
    }

    protected EnvironmentBase(double distance)
        : this(distance, Array.Empty<ObstacleBase>())
    {
    }

    public IReadOnlyList<ObstacleBase> Obstacles => _obstacles;
    public double Distance { get; }
}
using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

public abstract class EnvironmentBase
{
    private readonly List<ObstacleBase> _obstacles;

    protected EnvironmentBase(double distance, IEnumerable<ObstacleBase>? obstacles = null)
    {
        Distance = distance;
        _obstacles = new List<ObstacleBase>(obstacles ?? Array.Empty<ObstacleBase>());
    }

    public IReadOnlyList<ObstacleBase> Obstacles => _obstacles;
    public double Distance { get; }
}
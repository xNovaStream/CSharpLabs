using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

public class Journey
{
    private readonly List<EnvironmentBase> _environments;

    public Journey(IEnumerable<EnvironmentBase> environments)
    {
        _environments = environments?.ToList() ?? throw new ArgumentNullException(nameof(environments));
    }

    public FlightReport Fly(SpaceShip spaceShip)
    {
        return FlightService.Fly(_environments, spaceShip);
    }
}
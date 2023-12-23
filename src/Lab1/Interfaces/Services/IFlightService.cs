using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Services;

public interface IFlightService
{
    public FlightReport Fly(EnvironmentBase environment, SpaceShip spaceShip);
    public FlightReport Fly(IEnumerable<EnvironmentBase> environments, SpaceShip spaceShip);
    public FlightReport Fly(Journey journey, SpaceShip spaceShip);
}
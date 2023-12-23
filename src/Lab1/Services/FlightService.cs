using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class FlightService : IFlightService
{
    private readonly IDamageService _damageService;

    public FlightService(IDamageService? damageService = null)
    {
        _damageService = damageService ?? new DamageService();
    }

    public FlightReport Fly(EnvironmentBase environment, SpaceShip spaceShip)
    {
        ArgumentNullException.ThrowIfNull(environment);
        ArgumentNullException.ThrowIfNull(spaceShip);

        _damageService.Damage(environment.Obstacles, spaceShip);
        return spaceShip.State switch
        {
            SpaceShipState.Alive => spaceShip.Move(environment),
            SpaceShipState.DeadCrew => new FlightReport(FlightResult.DeadCrew),
            SpaceShipState.Destroyed => new FlightReport(FlightResult.DestroyedShip),
            SpaceShipState.Lost => new FlightReport(FlightResult.LostShip),
            _ => throw new NotImplementedException(),
        };
    }

    public FlightReport Fly(IEnumerable<EnvironmentBase> environments, SpaceShip spaceShip)
    {
        ArgumentNullException.ThrowIfNull(environments);
        ArgumentNullException.ThrowIfNull(spaceShip);

        return environments.Aggregate(
            new FlightReport(FlightResult.Successful),
            (flightReport, environment) =>
            {
                flightReport.Add(Fly(environment, spaceShip));
                return flightReport;
            });
    }

    public FlightReport Fly(Journey journey, SpaceShip spaceShip)
    {
        ArgumentNullException.ThrowIfNull(journey);
        ArgumentNullException.ThrowIfNull(spaceShip);

        return Fly(journey.Environments, spaceShip);
    }
}
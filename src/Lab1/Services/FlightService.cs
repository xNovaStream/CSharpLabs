using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class FlightService
{
    public static FlightReport Fly(EnvironmentBase environment, SpaceShip spaceShip)
    {
        ArgumentNullException.ThrowIfNull(environment);
        ArgumentNullException.ThrowIfNull(spaceShip);

        DamageService.Damage(environment.Obstacles, spaceShip);
        return spaceShip.State switch
        {
            SpaceShipState.Alive => spaceShip.Move(environment),
            SpaceShipState.DeadCrew => new FlightReport(FlightResult.DeadCrew),
            SpaceShipState.Destroyed => new FlightReport(FlightResult.DestroyedShip),
            SpaceShipState.Lost => new FlightReport(FlightResult.LostShip),
            _ => throw new NotImplementedException(),
        };
    }

    public static FlightReport Fly(IEnumerable<EnvironmentBase> environments, SpaceShip spaceShip)
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
}
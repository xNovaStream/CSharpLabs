using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class JourneyDataGenerator
{
    public static IEnumerable<object[]> JumpDataGenerate()
    {
        yield return new object[] { SpaceShipBuilder.CreatePleasureShuttle(), FlightResult.ImpassableEnvironment };
        yield return new object[] { SpaceShipBuilder.CreateAugur(), FlightResult.LostShip };
    }

    public static IEnumerable<object[]> AntimatterFlareDataGenerate()
    {
        yield return new object[] { SpaceShipBuilder.CreateVaclas(), FlightResult.DeadCrew };
        yield return new object[] { SpaceShipBuilder.CreateVaclas(true), FlightResult.Successful };
    }

    public static IEnumerable<object[]> SpaceWhaleDataGenerate()
    {
        yield return new object[] { SpaceShipBuilder.CreateVaclas(), false, FlightResult.DestroyedShip };
        yield return new object[] { SpaceShipBuilder.CreateAugur(), false, FlightResult.Successful };
        yield return new object[] { SpaceShipBuilder.CreateMeredian(), true, FlightResult.Successful };
    }
}
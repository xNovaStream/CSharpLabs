using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class JourneyDataGenerator
{
    public static IEnumerable<object[]> JumpDataGenerate()
    {
        SpaceShipBuilder spaceShipBuilder = new();

        yield return new object[] { spaceShipBuilder.CreatePleasureShuttle(), FlightResult.ImpassableEnvironment };
        yield return new object[] { spaceShipBuilder.CreateAugur(), FlightResult.LostShip };
    }

    public static IEnumerable<object[]> AntimatterFlareDataGenerate()
    {
        SpaceShipBuilder spaceShipBuilder = new();

        yield return new object[] { spaceShipBuilder.CreateVaclas(), FlightResult.DeadCrew };
        yield return new object[] { spaceShipBuilder.CreateVaclas(true), FlightResult.Successful };
    }

    public static IEnumerable<object[]> SpaceWhaleDataGenerate()
    {
        SpaceShipBuilder spaceShipBuilder = new();

        yield return new object[] { spaceShipBuilder.CreateVaclas(), false, FlightResult.DestroyedShip };
        yield return new object[] { spaceShipBuilder.CreateAugur(), false, FlightResult.Successful };
        yield return new object[] { spaceShipBuilder.CreateMeredian(), true, FlightResult.Successful };
    }
}
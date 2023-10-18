using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class JourneyTestSuite
{
    public static IEnumerable<object[]> JumpDataGenerator()
    {
        yield return new object[] { SpaceShipBuilder.CreatePleasureShuttle(), FlightResult.ImpassableEnvironment };
        yield return new object[] { SpaceShipBuilder.CreateAugur(), FlightResult.LostShip };
    }

    public static IEnumerable<object[]> AntimatterFlareDataGenerator()
    {
        yield return new object[] { SpaceShipBuilder.CreateVaclas(), FlightResult.DeadCrew };
        yield return new object[] { SpaceShipBuilder.CreateVaclas(true), FlightResult.Successful };
    }

    public static IEnumerable<object[]> SpaceWhaleDataGenerator()
    {
        yield return new object[] { SpaceShipBuilder.CreateVaclas(), false, FlightResult.DestroyedShip };
        yield return new object[] { SpaceShipBuilder.CreateAugur(), false, FlightResult.Successful };
        yield return new object[] { SpaceShipBuilder.CreateMeredian(), true, FlightResult.Successful };
    }

    [Theory]
    [MemberData(nameof(JumpDataGenerator))]
    public void JumpTest(SpaceShip spaceShip, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        var journey = new Journey(new[] { new HighDensityNebulae(50) });

        Assert.Equal(expectedFlightResult, journey.Fly(spaceShip).Result);
    }

    [Theory]
    [MemberData(nameof(AntimatterFlareDataGenerator))]
    public void AntimatterFlareTest(SpaceShip spaceShip, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        var journey = new Journey(new[]
            {
                new HighDensityNebulae(50, new[] { ObstacleBuilder.CreateAntimatterFlare() }),
            });

        Assert.Equal(expectedFlightResult, journey.Fly(spaceShip).Result);
    }

    [Theory]
    [MemberData(nameof(SpaceWhaleDataGenerator))]
    public void SpaceWhaleTest(SpaceShip spaceShip, bool extendedDeflectorState, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        var journey = new Journey(new[]
        {
            new NeutrinoNebulae(50, new[] { ObstacleBuilder.CreateSpaceWhale() }),
        });

        Assert.Equal(expectedFlightResult, journey.Fly(spaceShip).Result);
        Assert.Equal(extendedDeflectorState, spaceShip.IsDeflectorActive);
    }

    [Fact]
    public void SmallJourneyComparisonTest()
    {
        var journey = new Journey(new[] { new Space(10) });

        SpaceShip pleasureShuttle = SpaceShipBuilder.CreatePleasureShuttle();
        SpaceShip augur = SpaceShipBuilder.CreateAugur();

        FlightReport pleasureShuttleReport = journey.Fly(pleasureShuttle);
        FlightReport augurReport = journey.Fly(augur);

        var flightReports = new List<FlightReport>(new[] { pleasureShuttleReport, augurReport });

        Assert.Equal(pleasureShuttleReport, FlightComparisonService.FindBestOfFuel(flightReports));
        Assert.Equal(pleasureShuttleReport, FlightComparisonService.FindBestOfTime(flightReports));
    }

    [Fact]
    public void JumpComparisonTest()
    {
        var journey = new Journey(new[] { new HighDensityNebulae(50) });

        SpaceShip stella = SpaceShipBuilder.CreateStella();
        SpaceShip augur = SpaceShipBuilder.CreateAugur();

        FlightReport augurReport = journey.Fly(augur);
        FlightReport stellaReport = journey.Fly(stella);

        var flightReports = new List<FlightReport>(new[] { augurReport, stellaReport });

        Assert.Equal(stellaReport, FlightComparisonService.FindBestOfFuel(flightReports));
        Assert.Equal(stellaReport, FlightComparisonService.FindBestOfTime(flightReports));
    }

    [Fact]
    public void NeutrinoNebulaeComparisonTest()
    {
        var journey = new Journey(new[] { new NeutrinoNebulae(50) });

        SpaceShip pleasureShuttle = SpaceShipBuilder.CreatePleasureShuttle();
        SpaceShip vaclas = SpaceShipBuilder.CreateVaclas();

        FlightReport pleasureShuttleReport = journey.Fly(pleasureShuttle);
        FlightReport vaclasReport = journey.Fly(vaclas);

        var flightReports = new List<FlightReport> { pleasureShuttleReport, vaclasReport };

        Assert.Equal(vaclasReport, FlightComparisonService.FindBestOfFuel(flightReports));
        Assert.Equal(vaclasReport, FlightComparisonService.FindBestOfTime(flightReports));
    }

    [Fact]
    public void MultipleSegmentsJourneyTest()
    {
        var journey = new Journey(new EnvironmentBase[]
        {
            new Space(100),
            new NeutrinoNebulae(100),
            new HighDensityNebulae(50, new[]
            {
                ObstacleBuilder.CreateAntimatterFlare(),
                ObstacleBuilder.CreateAntimatterFlare(),
            }),
            new Space(10, new[]
            {
                ObstacleBuilder.CreateSmallAsteroid(),
                ObstacleBuilder.CreateMeteorite(),
                ObstacleBuilder.CreateMeteorite(),
            }),
        });

        SpaceShip pleasureShuttle = SpaceShipBuilder.CreatePleasureShuttle();
        SpaceShip vaclas = SpaceShipBuilder.CreateVaclas(true);
        SpaceShip meredian = SpaceShipBuilder.CreateMeredian();
        SpaceShip stella = SpaceShipBuilder.CreateStella();
        SpaceShip augur = SpaceShipBuilder.CreateAugur(true);

        FlightReport pleasureShuttleReport = journey.Fly(pleasureShuttle);
        FlightReport vaclasReport = journey.Fly(vaclas);
        FlightReport meredianReport = journey.Fly(meredian);
        FlightReport stellaReport = journey.Fly(stella);
        FlightReport augurReport = journey.Fly(augur);

        var flightReports = new List<FlightReport>
        {
            pleasureShuttleReport,
            vaclasReport,
            meredianReport,
            stellaReport,
            augurReport,
        };

        Assert.Equal(vaclasReport, FlightComparisonService.FindBestOfFuel(flightReports));
        Assert.Equal(vaclasReport, FlightComparisonService.FindBestOfTime(flightReports));
    }
}
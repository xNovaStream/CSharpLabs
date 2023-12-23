using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Builders;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class JourneyTestSuite
{
    [Theory]
    [MemberData(nameof(JourneyDataGenerator.JumpDataGenerate), MemberType = typeof(JourneyDataGenerator))]
    public void JumpTest(SpaceShip spaceShip, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        // arrange
        var flightService = new FlightService();

        var journey = new Journey(new[] { new HighDensityNebulae(50) });

        // act
        FlightReport spaceShipReport = flightService.Fly(journey, spaceShip);

        // assert
        Assert.Equal(expectedFlightResult, spaceShipReport.Result);
    }

    [Theory]
    [MemberData(nameof(JourneyDataGenerator.AntimatterFlareDataGenerate), MemberType = typeof(JourneyDataGenerator))]
    public void AntimatterFlareTest(SpaceShip spaceShip, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        // arrange
        var flightService = new FlightService();
        var obstacleBuilder = new ObstacleBuilder();

        var journey = new Journey(new[]
            {
                new HighDensityNebulae(50, new[] { obstacleBuilder.CreateAntimatterFlare() }),
            });

        // act
        FlightReport spaceShipReport = flightService.Fly(journey, spaceShip);

        // assert
        Assert.Equal(expectedFlightResult, spaceShipReport.Result);
    }

    [Theory]
    [MemberData(nameof(JourneyDataGenerator.SpaceWhaleDataGenerate), MemberType = typeof(JourneyDataGenerator))]
    public void SpaceWhaleTest(SpaceShip spaceShip, bool expectedDeflectorState, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        // arrange
        var flightService = new FlightService();
        var obstacleBuilder = new ObstacleBuilder();

        var journey = new Journey(new[]
        {
            new NeutrinoNebulae(50, new[] { obstacleBuilder.CreateSpaceWhale() }),
        });

        // act
        FlightReport spaceShipReport = flightService.Fly(journey, spaceShip);

        // assert
        Assert.Equal(expectedFlightResult, spaceShipReport.Result);
        Assert.Equal(expectedDeflectorState, spaceShip.IsDeflectorActive);
    }

    [Fact]
    public void SmallJourneyComparisonTest()
    {
        // arrange
        var flightService = new FlightService();
        var flightComparisonService = new FlightComparisonService();

        var spaceShipBuilder = new SpaceShipBuilder();

        var journey = new Journey(new[] { new Space(10) });

        SpaceShip pleasureShuttle = spaceShipBuilder.CreatePleasureShuttle();
        SpaceShip augur = spaceShipBuilder.CreateAugur();

        // act
        FlightReport pleasureShuttleReport = flightService.Fly(journey, pleasureShuttle);
        FlightReport augurReport = flightService.Fly(journey, augur);

        var flightReports = new List<FlightReport>(new[] { pleasureShuttleReport, augurReport });

        FlightReport? bestOfFuelReport = flightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = flightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(pleasureShuttleReport, bestOfFuelReport);
        Assert.Equal(pleasureShuttleReport, bestOfTimeReport);
    }

    [Fact]
    public void JumpComparisonTest()
    {
        // arrange
        var flightService = new FlightService();
        var flightComparisonService = new FlightComparisonService();

        var spaceShipBuilder = new SpaceShipBuilder();

        var journey = new Journey(new[] { new HighDensityNebulae(50) });

        SpaceShip stella = spaceShipBuilder.CreateStella();
        SpaceShip augur = spaceShipBuilder.CreateAugur();

        // act
        FlightReport augurReport = flightService.Fly(journey, augur);
        FlightReport stellaReport = flightService.Fly(journey, stella);

        var flightReports = new List<FlightReport>(new[] { augurReport, stellaReport });

        FlightReport? bestOfFuelReport = flightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = flightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(stellaReport, bestOfFuelReport);
        Assert.Equal(stellaReport, bestOfTimeReport);
    }

    [Fact]
    public void NeutrinoNebulaeComparisonTest()
    {
        // arrange
        var flightService = new FlightService();
        var flightComparisonService = new FlightComparisonService();

        var spaceShipBuilder = new SpaceShipBuilder();

        var journey = new Journey(new[] { new NeutrinoNebulae(50) });

        SpaceShip pleasureShuttle = spaceShipBuilder.CreatePleasureShuttle();
        SpaceShip vaclas = spaceShipBuilder.CreateVaclas();

        // act
        FlightReport pleasureShuttleReport = flightService.Fly(journey, pleasureShuttle);
        FlightReport vaclasReport = flightService.Fly(journey, vaclas);

        var flightReports = new List<FlightReport> { pleasureShuttleReport, vaclasReport };

        FlightReport? bestOfFuelReport = flightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = flightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(vaclasReport, bestOfFuelReport);
        Assert.Equal(vaclasReport, bestOfTimeReport);
    }

    [Fact]
    public void MultipleSegmentsJourneyTest()
    {
        // arrange
        var flightService = new FlightService();
        var flightComparisonService = new FlightComparisonService();

        var spaceShipBuilder = new SpaceShipBuilder();
        var obstacleBuilder = new ObstacleBuilder();

        var journey = new Journey(new EnvironmentBase[]
        {
            new Space(100),
            new NeutrinoNebulae(100),
            new HighDensityNebulae(50, new[]
            {
                obstacleBuilder.CreateAntimatterFlare(),
                obstacleBuilder.CreateAntimatterFlare(),
            }),
            new Space(10, new[]
            {
                obstacleBuilder.CreateSmallAsteroid(),
                obstacleBuilder.CreateMeteorite(),
                obstacleBuilder.CreateMeteorite(),
            }),
        });

        SpaceShip pleasureShuttle = spaceShipBuilder.CreatePleasureShuttle();
        SpaceShip vaclas = spaceShipBuilder.CreateVaclas(true);
        SpaceShip meredian = spaceShipBuilder.CreateMeredian();
        SpaceShip stella = spaceShipBuilder.CreateStella();
        SpaceShip augur = spaceShipBuilder.CreateAugur(true);

        // act
        FlightReport pleasureShuttleReport = flightService.Fly(journey, pleasureShuttle);
        FlightReport vaclasReport = flightService.Fly(journey, vaclas);
        FlightReport meredianReport = flightService.Fly(journey, meredian);
        FlightReport stellaReport = flightService.Fly(journey, stella);
        FlightReport augurReport = flightService.Fly(journey, augur);

        var flightReports = new List<FlightReport>
        {
            pleasureShuttleReport,
            vaclasReport,
            meredianReport,
            stellaReport,
            augurReport,
        };

        FlightReport? bestOfFuelReport = flightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = flightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(vaclasReport, bestOfFuelReport);
        Assert.Equal(vaclasReport, bestOfTimeReport);
    }
}
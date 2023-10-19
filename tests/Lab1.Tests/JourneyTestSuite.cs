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
    [Theory]
    [MemberData(nameof(JourneyDataGenerator.JumpDataGenerate), MemberType = typeof(JourneyDataGenerator))]
    public void JumpTest(SpaceShip spaceShip, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        // arrange
        var journey = new Journey(new[] { new HighDensityNebulae(50) });

        // act
        FlightReport spaceShipReport = journey.Fly(spaceShip);

        // assert
        Assert.Equal(expectedFlightResult, spaceShipReport.Result);
    }

    [Theory]
    [MemberData(nameof(JourneyDataGenerator.AntimatterFlareDataGenerate), MemberType = typeof(JourneyDataGenerator))]
    public void AntimatterFlareTest(SpaceShip spaceShip, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        // arrange
        var journey = new Journey(new[]
            {
                new HighDensityNebulae(50, new[] { ObstacleBuilder.CreateAntimatterFlare() }),
            });

        // act
        FlightReport spaceShipReport = journey.Fly(spaceShip);

        // assert
        Assert.Equal(expectedFlightResult, spaceShipReport.Result);
    }

    [Theory]
    [MemberData(nameof(JourneyDataGenerator.SpaceWhaleDataGenerate), MemberType = typeof(JourneyDataGenerator))]
    public void SpaceWhaleTest(SpaceShip spaceShip, bool expectedDeflectorState, FlightResult expectedFlightResult)
    {
        ArgumentNullException.ThrowIfNull(spaceShip);

        // arrange
        var journey = new Journey(new[]
        {
            new NeutrinoNebulae(50, new[] { ObstacleBuilder.CreateSpaceWhale() }),
        });

        // act
        FlightReport spaceShipReport = journey.Fly(spaceShip);

        // assert
        Assert.Equal(expectedFlightResult, spaceShipReport.Result);
        Assert.Equal(expectedDeflectorState, spaceShip.IsDeflectorActive);
    }

    [Fact]
    public void SmallJourneyComparisonTest()
    {
        // arrange
        var journey = new Journey(new[] { new Space(10) });

        SpaceShip pleasureShuttle = SpaceShipBuilder.CreatePleasureShuttle();
        SpaceShip augur = SpaceShipBuilder.CreateAugur();

        // act
        FlightReport pleasureShuttleReport = journey.Fly(pleasureShuttle);
        FlightReport augurReport = journey.Fly(augur);

        var flightReports = new List<FlightReport>(new[] { pleasureShuttleReport, augurReport });

        FlightReport? bestOfFuelReport = FlightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = FlightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(pleasureShuttleReport, bestOfFuelReport);
        Assert.Equal(pleasureShuttleReport, bestOfTimeReport);
    }

    [Fact]
    public void JumpComparisonTest()
    {
        // arrange
        var journey = new Journey(new[] { new HighDensityNebulae(50) });

        SpaceShip stella = SpaceShipBuilder.CreateStella();
        SpaceShip augur = SpaceShipBuilder.CreateAugur();

        // act
        FlightReport augurReport = journey.Fly(augur);
        FlightReport stellaReport = journey.Fly(stella);

        var flightReports = new List<FlightReport>(new[] { augurReport, stellaReport });

        FlightReport? bestOfFuelReport = FlightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = FlightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(stellaReport, bestOfFuelReport);
        Assert.Equal(stellaReport, bestOfTimeReport);
    }

    [Fact]
    public void NeutrinoNebulaeComparisonTest()
    {
        // arrange
        var journey = new Journey(new[] { new NeutrinoNebulae(50) });

        SpaceShip pleasureShuttle = SpaceShipBuilder.CreatePleasureShuttle();
        SpaceShip vaclas = SpaceShipBuilder.CreateVaclas();

        // act
        FlightReport pleasureShuttleReport = journey.Fly(pleasureShuttle);
        FlightReport vaclasReport = journey.Fly(vaclas);

        var flightReports = new List<FlightReport> { pleasureShuttleReport, vaclasReport };

        FlightReport? bestOfFuelReport = FlightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = FlightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(vaclasReport, bestOfFuelReport);
        Assert.Equal(vaclasReport, bestOfTimeReport);
    }

    [Fact]
    public void MultipleSegmentsJourneyTest()
    {
        // arrange
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

        // act
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

        FlightReport? bestOfFuelReport = FlightComparisonService.FindBestOfFuel(flightReports);
        FlightReport? bestOfTimeReport = FlightComparisonService.FindBestOfTime(flightReports);

        // assert
        Assert.Equal(vaclasReport, bestOfFuelReport);
        Assert.Equal(vaclasReport, bestOfTimeReport);
    }
}
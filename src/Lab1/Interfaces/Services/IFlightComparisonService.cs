using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces.Services;

public interface IFlightComparisonService
{
    public IEnumerable<FlightReport> WhereSuccessfulResult(IEnumerable<FlightReport> flightReports);

    public FlightReport? FindBestOfTime(IEnumerable<FlightReport> flightReports);
    public FlightReport? FindBestOfFuel(IEnumerable<FlightReport> flightReports);
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class FlightComparisonService
{
    public static IEnumerable<FlightReport> WhereSuccessfulResult(IEnumerable<FlightReport> flightReports)
    {
        ArgumentNullException.ThrowIfNull(flightReports);

        return flightReports.Where(flightReport =>
        {
            ArgumentNullException.ThrowIfNull(flightReport);
            return flightReport.Result == FlightResult.Successful;
        });
    }

    public static FlightReport? FindBestOfTime(IEnumerable<FlightReport> flightReports)
    {
        ArgumentNullException.ThrowIfNull(flightReports);

        return WhereSuccessfulResult(flightReports).Min(Comparer<FlightReport>.Create((flightReport1, flightReport2) =>
            Comparer.Default.Compare(flightReport1.SpentTime, flightReport2.SpentTime) == 0
                ? Comparer.Default.Compare(flightReport1.SpentFuel, flightReport2.SpentFuel)
                : Comparer.Default.Compare(flightReport1.SpentTime, flightReport2.SpentTime)));
    }

    public static FlightReport? FindBestOfFuel(IEnumerable<FlightReport> flightReports)
    {
        ArgumentNullException.ThrowIfNull(flightReports);

        return WhereSuccessfulResult(flightReports).Min(Comparer<FlightReport>.Create((flightReport1, flightReport2) =>
            Comparer.Default.Compare(flightReport1.SpentFuel, flightReport2.SpentFuel) == 0
                ? Comparer.Default.Compare(flightReport1.SpentTime, flightReport2.SpentTime)
                : Comparer.Default.Compare(flightReport1.SpentFuel, flightReport2.SpentFuel)));
    }
}
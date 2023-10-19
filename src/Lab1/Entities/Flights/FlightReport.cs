using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Flights;

public class FlightReport
{
    public FlightReport(FlightResult result, double spentFuel = 0, double spentTime = 0)
    {
        Result = result;
        SpentFuel = spentFuel >= 0 ? spentFuel : throw new InvalidSpentFuelException();
        SpentTime = spentTime >= 0 ? spentTime : throw new InvalidSpentTimeException();
    }

    public FlightResult Result { get; private set; }
    public double SpentFuel { get; private set; }
    public double SpentTime { get; private set; }

    public void Add(FlightReport flightReport)
    {
        ArgumentNullException.ThrowIfNull(flightReport);

        if (Result != FlightResult.Successful) return;

        Result = flightReport.Result;
        SpentFuel += flightReport.SpentFuel;
        SpentTime += flightReport.SpentTime;
    }
}
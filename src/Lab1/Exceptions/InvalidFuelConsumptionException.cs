using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidFuelConsumptionException : Exception
{
    public InvalidFuelConsumptionException(string message)
        : base(message)
    {
    }

    public InvalidFuelConsumptionException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidFuelConsumptionException()
    {
    }
}
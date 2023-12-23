using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidSpentFuelException : Exception
{
    public InvalidSpentFuelException(string message)
        : base(message)
    {
    }

    public InvalidSpentFuelException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidSpentFuelException()
    {
    }
}
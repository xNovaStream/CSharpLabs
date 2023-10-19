using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidStartFuelException : Exception
{
    public InvalidStartFuelException(string message)
        : base(message)
    {
    }

    public InvalidStartFuelException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidStartFuelException()
    {
    }
}
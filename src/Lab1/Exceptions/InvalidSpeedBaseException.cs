using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidSpeedBaseException : Exception
{
    public InvalidSpeedBaseException(string message)
        : base(message)
    {
    }

    public InvalidSpeedBaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidSpeedBaseException()
    {
    }
}
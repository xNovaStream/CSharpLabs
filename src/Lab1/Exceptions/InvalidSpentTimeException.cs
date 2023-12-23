using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidSpentTimeException : Exception
{
    public InvalidSpentTimeException(string message)
        : base(message)
    {
    }

    public InvalidSpentTimeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidSpentTimeException()
    {
    }
}
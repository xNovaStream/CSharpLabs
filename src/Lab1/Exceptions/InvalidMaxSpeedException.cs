using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidMaxSpeedException : Exception
{
    public InvalidMaxSpeedException(string message)
        : base(message)
    {
    }

    public InvalidMaxSpeedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidMaxSpeedException()
    {
    }
}
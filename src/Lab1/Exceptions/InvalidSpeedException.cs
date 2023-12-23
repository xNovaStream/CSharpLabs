using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class InvalidSpeedException : Exception
{
    public InvalidSpeedException(string message)
        : base(message)
    {
    }

    public InvalidSpeedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidSpeedException()
    {
    }
}
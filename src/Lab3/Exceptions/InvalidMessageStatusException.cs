using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class InvalidMessageStatusException : Exception
{
    public InvalidMessageStatusException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidMessageStatusException(string message)
        : base(message)
    {
    }

    public InvalidMessageStatusException()
    {
    }
}
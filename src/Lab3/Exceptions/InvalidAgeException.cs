using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class InvalidAgeException : Exception
{
    public InvalidAgeException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidAgeException(string message)
        : base(message)
    {
    }

    public InvalidAgeException()
    {
    }
}
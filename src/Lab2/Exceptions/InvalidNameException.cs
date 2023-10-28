using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class InvalidNameException : Exception
{
    public InvalidNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidNameException(string message)
        : base(message)
    {
    }

    public InvalidNameException()
    {
    }
}
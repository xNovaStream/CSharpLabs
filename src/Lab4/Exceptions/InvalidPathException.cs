using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class InvalidPathException : Exception
{
    public InvalidPathException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidPathException(string message)
        : base(message)
    {
    }

    public InvalidPathException()
    {
    }
}
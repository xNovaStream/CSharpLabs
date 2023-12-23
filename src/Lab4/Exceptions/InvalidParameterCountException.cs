using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class InvalidParameterCountException : Exception
{
    public InvalidParameterCountException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidParameterCountException(string message)
        : base(message)
    {
    }

    public InvalidParameterCountException()
    {
    }
}
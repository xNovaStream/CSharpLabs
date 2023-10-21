using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class InvalidComponentNameException : Exception
{
    public InvalidComponentNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidComponentNameException(string message)
        : base(message)
    {
    }

    public InvalidComponentNameException()
    {
    }
}
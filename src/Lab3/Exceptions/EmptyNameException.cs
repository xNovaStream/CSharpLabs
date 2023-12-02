using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class EmptyNameException : Exception
{
    public EmptyNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmptyNameException(string message)
        : base(message)
    {
    }

    public EmptyNameException()
    {
    }
}
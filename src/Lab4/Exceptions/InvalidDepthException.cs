using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class InvalidDepthException : Exception
{
    public InvalidDepthException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidDepthException(string message)
        : base(message)
    {
    }

    public InvalidDepthException()
    {
    }
}
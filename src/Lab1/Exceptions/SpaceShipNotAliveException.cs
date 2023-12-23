using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class SpaceShipNotAliveException : Exception
{
    public SpaceShipNotAliveException(string message)
        : base(message)
    {
    }

    public SpaceShipNotAliveException()
    {
    }

    public SpaceShipNotAliveException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class WifiAdapterValidationException : Exception
{
    public WifiAdapterValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public WifiAdapterValidationException(string message)
        : base(message)
    {
    }

    public WifiAdapterValidationException()
    {
    }
}
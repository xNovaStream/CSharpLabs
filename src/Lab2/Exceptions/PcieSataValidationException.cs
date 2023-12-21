using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PcieSataValidationException : Exception
{
    public PcieSataValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PcieSataValidationException(string message)
        : base(message)
    {
    }

    public PcieSataValidationException()
    {
    }
}
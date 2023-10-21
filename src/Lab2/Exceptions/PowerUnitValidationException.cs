using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class PowerUnitValidationException : Exception
{
    public PowerUnitValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PowerUnitValidationException(string message)
        : base(message)
    {
    }

    public PowerUnitValidationException()
    {
    }
}
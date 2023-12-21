using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class RamValidationException : Exception
{
    public RamValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public RamValidationException(string message)
        : base(message)
    {
    }

    public RamValidationException()
    {
    }
}
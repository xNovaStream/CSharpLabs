using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CpuValidationException : Exception
{
    public CpuValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CpuValidationException(string message)
        : base(message)
    {
    }

    public CpuValidationException()
    {
    }
}
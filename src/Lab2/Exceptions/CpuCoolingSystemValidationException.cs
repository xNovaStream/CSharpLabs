using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CpuCoolingSystemValidationException : Exception
{
    public CpuCoolingSystemValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CpuCoolingSystemValidationException(string message)
        : base(message)
    {
    }

    public CpuCoolingSystemValidationException()
    {
    }
}
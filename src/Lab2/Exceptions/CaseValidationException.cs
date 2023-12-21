using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class CaseValidationException : Exception
{
    public CaseValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CaseValidationException(string message)
        : base(message)
    {
    }

    public CaseValidationException()
    {
    }
}
using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class InvalidImportanceLevelException : Exception
{
    public InvalidImportanceLevelException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidImportanceLevelException(string message)
        : base(message)
    {
    }

    public InvalidImportanceLevelException()
    {
    }
}
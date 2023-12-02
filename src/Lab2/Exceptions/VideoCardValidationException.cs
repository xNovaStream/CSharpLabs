using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class VideoCardValidationException : Exception
{
    public VideoCardValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public VideoCardValidationException(string message)
        : base(message)
    {
    }

    public VideoCardValidationException()
    {
    }
}
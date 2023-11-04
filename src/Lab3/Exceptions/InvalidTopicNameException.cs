using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class InvalidTopicNameException : Exception
{
    public InvalidTopicNameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidTopicNameException(string message)
        : base(message)
    {
    }

    public InvalidTopicNameException()
    {
    }
}
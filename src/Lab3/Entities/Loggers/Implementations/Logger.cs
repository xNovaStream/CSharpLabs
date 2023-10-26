using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers.Implementations;

public class Logger : ILogger
{
    public void Log(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        Console.WriteLine(text);
    }
}
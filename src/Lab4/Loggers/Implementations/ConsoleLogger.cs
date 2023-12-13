using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Loggers.Implementations;

public class ConsoleLogger : ILogger
{
    public void Log(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        Console.WriteLine(text);
    }

    public void ExceptionLog(string text)
    {
        ArgumentNullException.ThrowIfNull(text);

        Log("Exception: " + text);
    }
}
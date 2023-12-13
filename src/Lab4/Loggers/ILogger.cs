namespace Itmo.ObjectOrientedProgramming.Lab4.Loggers;

public interface ILogger
{
    public void Log(string text);
    public void ExceptionLog(string text);
}
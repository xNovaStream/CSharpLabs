using System;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class InvalidCommand : ICommand
{
    private readonly ILogger _logger;
    private readonly string _exceptionMessage;

    public InvalidCommand(ILogger logger, string exceptionMessage)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(exceptionMessage);

        _logger = logger;
        _exceptionMessage = exceptionMessage;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        _logger.ExceptionLog(_exceptionMessage);
    }
}
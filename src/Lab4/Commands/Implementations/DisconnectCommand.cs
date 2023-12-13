using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class DisconnectCommand : ICommand
{
    private readonly ILogger _logger;

    public DisconnectCommand(ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(logger);

        _logger = logger;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        fileSystemContext.Connect(new NullFileSystem(_logger));
    }
}
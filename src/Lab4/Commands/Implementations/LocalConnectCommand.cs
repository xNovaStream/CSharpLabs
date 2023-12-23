using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class LocalConnectCommand : ICommand
{
    private readonly ILogger _logger;
    private readonly string _path;

    public LocalConnectCommand(ILogger logger, string path)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(path);

        _logger = logger;
        _path = path;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        fileSystemContext.Connect(new LocalFileSystem(_logger, _path));
    }
}
using System;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class FileShowConsoleCommand : ICommand
{
    private readonly IWriter _writer;
    private readonly string _path;

    public FileShowConsoleCommand(IWriter writer, string path)
    {
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentNullException.ThrowIfNull(path);

        _writer = writer;
        _path = path;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        fileSystemContext.FileSystem.FileShow(_writer, _path);
    }
}
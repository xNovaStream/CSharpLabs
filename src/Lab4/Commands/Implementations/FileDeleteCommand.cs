using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        _path = path;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        throw new NotImplementedException();
    }
}
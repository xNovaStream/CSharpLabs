using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class TreeGotoCommand : ICommand
{
    private readonly string _path;

    public TreeGotoCommand(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        _path = path;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        fileSystemContext.FileSystem.SetRelativePath(_path);
    }
}
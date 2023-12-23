using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(string path, string newName)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(newName);

        _path = path;
        _newName = newName;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        fileSystemContext.FileSystem.FileRename(_path, _newName);
    }
}
using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class FileMoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileMoveCommand(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);

        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        fileSystemContext.FileSystem.FileMove(_sourcePath, _destinationPath);
    }
}
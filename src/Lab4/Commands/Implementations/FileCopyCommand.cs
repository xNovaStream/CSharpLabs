using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);

        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        throw new NotImplementedException();
    }
}
using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileSystemContext
{
    public FileSystemContext(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        FileSystem = fileSystem;
    }

    public IFileSystem FileSystem { get; private set; }

    public void Connect(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);

        FileSystem = fileSystem;
    }
}
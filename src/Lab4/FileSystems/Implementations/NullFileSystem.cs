using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Implementations;

public class NullFileSystem : IFileSystem
{
    private readonly ILogger _logger;

    public NullFileSystem(ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(logger);

        _logger = logger;
    }

    public void SetRelativePath(string path)
    {
        _logger.ExceptionLog("File system is not connected");
    }

    public void ShowTreeList(IFileSystemVisitor visitor)
    {
        _logger.ExceptionLog("File system is not connected");
    }

    public void FileShow(IWriter writer, string path)
    {
        _logger.ExceptionLog("File system is not connected");
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        _logger.ExceptionLog("File system is not connected");
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        _logger.ExceptionLog("File system is not connected");
    }

    public void FileDelete(string path)
    {
        _logger.ExceptionLog("File system is not connected");
    }

    public void FileRename(string path, string newName)
    {
        _logger.ExceptionLog("File system is not connected");
    }
}
using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Directories.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Implementations;

public class LocalFileSystem : IFileSystem
{
    private readonly ILogger _logger;
    private readonly string _root;
    private string _relativePath;

    public LocalFileSystem(ILogger logger, string path)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(path);

        _logger = logger;
        _relativePath = path;
        _root = Path.GetPathRoot(_relativePath) ?? string.Empty;
    }

    public void SetRelativePath(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        if (!Contains(path))
        {
            _logger.ExceptionLog("Path must be in file system");
            return;
        }

        _relativePath = GetFullPath(path);
    }

    public void ShowTreeList(IFileSystemVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);

        visitor.VisitDirectory(new LocalDirectory(_relativePath));
    }

    public void FileShow(IWriter writer, string path)
    {
        ArgumentNullException.ThrowIfNull(writer);
        ArgumentNullException.ThrowIfNull(path);
        if (!Contains(path))
        {
            _logger.ExceptionLog("Path must be in file system");
            return;
        }

        writer.WriteLine(new LocalFile(GetFullPath(path)).Read());
    }

    public void FileMove(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);
        if (!Contains(sourcePath) || !Contains(destinationPath))
        {
            _logger.ExceptionLog("Path must be in file system");
            return;
        }

        new LocalFile(GetFullPath(sourcePath)).Move(GetFullPath(destinationPath));
    }

    public void FileCopy(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);
        if (!Contains(sourcePath) || !Contains(destinationPath))
        {
            _logger.ExceptionLog("Path must be in file system");
            return;
        }

        new LocalFile(GetFullPath(sourcePath)).Copy(GetFullPath(destinationPath));
    }

    public void FileDelete(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        if (!Contains(path))
        {
            _logger.ExceptionLog("Path must be in file system");
            return;
        }

        new LocalFile(GetFullPath(path)).Delete();
    }

    public void FileRename(string path, string newName)
    {
        ArgumentNullException.ThrowIfNull(path);
        ArgumentNullException.ThrowIfNull(newName);

        new LocalFile(GetFullPath(path)).Rename(newName);
    }

    private string GetFullPath(string path) => Path.GetFullPath(Path.Combine(_relativePath, path));
    private bool Contains(string path) => Path.IsPathRooted(path) &&
                                          Path.GetPathRoot(path) != _root &&
                                          Path.Exists(GetFullPath(path));
}
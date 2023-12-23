using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.Builders.Implementations;

public class LocalFileSystemBuilder : IFileSystemBuilder
{
    private readonly ILogger _logger;
    private readonly string _path;

    public LocalFileSystemBuilder(ILogger logger, string path)
    {
        ArgumentNullException.ThrowIfNull(logger);
        ArgumentNullException.ThrowIfNull(path);

        _logger = logger;
        _path = path;
    }

    public IFileSystem Build()
    {
        if (!Path.IsPathFullyQualified(_path))
        {
            _logger.ExceptionLog("Path must be fully qualified");
            return new NullFileSystem(_logger);
        }

        if (!Directory.Exists(_path))
        {
            _logger.ExceptionLog("Path must be existed");
            return new NullFileSystem(_logger);
        }

        return new LocalFileSystem(_logger, Path.GetFullPath(_path));
    }
}
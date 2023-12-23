using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Files.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.PathValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Directories.Implementations;

public class LocalDirectory : IDirectory
{
    private readonly string _path;
    private readonly LocalPathValidator _pathValidator;

    public LocalDirectory(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        _pathValidator = new LocalPathValidator(path);

        if (!_pathValidator.IsValidDirectory())
            throw new InvalidPathException("Directory not exist or path not fully qualified");

        _path = path;
    }

    public string GetName()
    {
        if (!_pathValidator.IsValidDirectory())
            throw new InvalidPathException("Directory not exist or path not fully qualified");

        return Path.GetPathRoot(_path) == Path.GetFullPath(_path) ? _path : Path.GetFileName(_path);
    }

    public IReadOnlyList<IFile> GetFiles()
    {
        if (!_pathValidator.IsValidDirectory())
            throw new InvalidPathException("Directory not exist or path not fully qualified");

        return Directory.GetFiles(_path).Select(path => new LocalFile(path)).ToList();
    }

    public IReadOnlyList<IDirectory> GetDirectories()
    {
        if (!_pathValidator.IsValidDirectory())
            throw new InvalidPathException("Directory not exist or path not fully qualified");

        return Directory.GetDirectories(_path).Select(path => new LocalDirectory(path)).ToList();
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);

        visitor.VisitDirectory(this);
    }
}
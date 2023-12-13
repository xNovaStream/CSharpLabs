using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.PathValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files.Implementations;

public class LocalFile : IFile
{
    private readonly string _path;
    private readonly LocalPathValidator _pathValidator;

    public LocalFile(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        _pathValidator = new LocalPathValidator(path);

        if (!_pathValidator.IsValidFile())
            throw new InvalidPathException("File not exist or path not fully qualified");

        _path = path;
    }

    public string GetName()
    {
        if (!_pathValidator.IsValidFile())
            throw new InvalidPathException("File not exist or path not fully qualified");

        return Path.GetFileName(_path);
    }

    public string Read()
    {
        if (!_pathValidator.IsValidFile())
            throw new InvalidPathException("File not exist or path not fully qualified");

        return File.ReadAllText(_path);
    }

    public void Move(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        if (!_pathValidator.IsValidFile())
            throw new InvalidPathException("File not exist or path not fully qualified");
        if (new LocalPathValidator(Path.Combine(path, GetName())).IsValidFile())
            throw new InvalidPathException("File already exist");

        File.Move(_path, Path.Combine(path, GetName()));
    }

    public void Copy(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        if (!_pathValidator.IsValidFile())
            throw new InvalidPathException("File not exist or path not fully qualified");
        if (new LocalPathValidator(Path.Combine(path, GetName())).IsValidFile())
            throw new InvalidPathException("File already exist");

        File.Move(_path, Path.Combine(path, GetName()));
    }

    public void Delete()
    {
        if (_pathValidator.IsValidFile()) throw new InvalidPathException();

        File.Delete(_path);
    }

    public void Rename(string newName)
    {
        ArgumentNullException.ThrowIfNull(newName);
        if (!_pathValidator.IsValidFile())
            throw new InvalidPathException("File not exist or path not fully qualified");
        if (new LocalPathValidator(Path.Combine(Path.GetDirectoryName(_path) ?? string.Empty, newName)).IsValidFile())
            throw new InvalidPathException("File already exist");

        File.Move(_path, Path.Combine(Path.GetDirectoryName(_path) ?? string.Empty, newName));
    }

    public void Accept(IFileSystemVisitor visitor)
    {
        ArgumentNullException.ThrowIfNull(visitor);

        visitor.VisitFile(this);
    }
}
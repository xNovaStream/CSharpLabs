using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.PathValidators;

public class LocalPathValidator
{
    private readonly string _path;

    public LocalPathValidator(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        _path = path;
    }

    public bool IsValidFile()
    {
        if (!Path.IsPathFullyQualified(_path)) return false;
        if (!File.Exists(_path)) return false;

        return true;
    }

    public bool IsValidDirectory()
    {
        if (!Path.IsPathFullyQualified(_path)) return false;
        if (!File.Exists(_path)) return false;

        return true;
    }
}
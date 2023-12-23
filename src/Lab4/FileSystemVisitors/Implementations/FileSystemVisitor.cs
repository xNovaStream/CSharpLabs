using System;
using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors.Implementations;

public class FileSystemVisitor : IFileSystemVisitor
{
    private readonly IWriter _writer;
    private readonly int _depth;
    private readonly int _maxDepth;

    public FileSystemVisitor(IWriter writer, int maxDepth)
        : this(writer, maxDepth, 0)
    {
        ArgumentNullException.ThrowIfNull(writer);
        if (maxDepth < 0) throw new InvalidDepthException();
    }

    private FileSystemVisitor(IWriter writer, int maxDepth, int depth)
    {
        _writer = writer;
        _maxDepth = maxDepth;
        _depth = depth;
    }

    public void VisitFile(IFile file)
    {
        ArgumentNullException.ThrowIfNull(file);

        _writer.WriteTreeListFile(file.GetName(), _depth);
    }

    public void VisitDirectory(IDirectory directory)
    {
        ArgumentNullException.ThrowIfNull(directory);

        _writer.WriteTreeListDirectory(directory.GetName(), _depth);

        if (_depth == _maxDepth) return;

        foreach (IFile file in directory.GetFiles())
        {
            file.Accept(new FileSystemVisitor(_writer, _maxDepth, _depth + 1));
        }

        foreach (IDirectory subdirectory in directory.GetDirectories())
        {
            subdirectory.Accept(new FileSystemVisitor(_writer, _maxDepth, _depth + 1));
        }
    }
}
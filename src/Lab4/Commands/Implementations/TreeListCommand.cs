using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors.Implementations;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class TreeListCommand : ICommand
{
    private readonly IWriter _writer;
    private readonly int _depth;

    public TreeListCommand(IWriter writer, int depth)
    {
        _writer = writer;
        _depth = depth;
    }

    public void Execute(FileSystemContext fileSystemContext)
    {
        ArgumentNullException.ThrowIfNull(fileSystemContext);

        fileSystemContext.FileSystem.ShowTreeList(new FileSystemVisitor(_writer, _depth));
    }
}
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Files;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Directories;

public interface IDirectory
{
    public string GetName();
    public IReadOnlyList<IFile> GetFiles();
    public IReadOnlyList<IDirectory> GetDirectories();
    public void Accept(IFileSystemVisitor visitor);
}
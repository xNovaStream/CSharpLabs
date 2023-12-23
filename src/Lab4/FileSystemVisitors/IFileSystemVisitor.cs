using Itmo.ObjectOrientedProgramming.Lab4.Directories;
using Itmo.ObjectOrientedProgramming.Lab4.Files;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;

public interface IFileSystemVisitor
{
    public void VisitFile(IFile file);
    public void VisitDirectory(IDirectory directory);
}
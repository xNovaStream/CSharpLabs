using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Files;

public interface IFile
{
    public string GetName();
    public string Read();
    public void Move(string path);
    public void Copy(string path);
    public void Delete();
    public void Rename(string newName);
    public void Accept(IFileSystemVisitor visitor);
}
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystem
{
    public void SetRelativePath(string path);
    public void ShowTreeList(IFileSystemVisitor visitor);
    public void FileShow(IWriter writer, string path);
    public void FileMove(string sourcePath, string destinationPath);
    public void FileCopy(string sourcePath, string destinationPath);
    public void FileDelete(string path);
    public void FileRename(string path, string newName);
}
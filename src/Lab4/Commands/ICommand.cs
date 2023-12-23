namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    public void Execute(FileSystemContext fileSystemContext);
}
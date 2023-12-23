using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

public class QuitCommand : ICommand
{
    public void Execute(FileSystemContext fileSystemContext)
    {
        Environment.Exit(0);
    }
}
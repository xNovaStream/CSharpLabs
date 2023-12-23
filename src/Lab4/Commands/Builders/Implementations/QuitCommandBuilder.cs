using Itmo.ObjectOrientedProgramming.Lab4.Commands.Implementations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Builders.Implementations;

public class QuitCommandBuilder : ICommandBuilder
{
    public ICommand Build() => new QuitCommand();
}
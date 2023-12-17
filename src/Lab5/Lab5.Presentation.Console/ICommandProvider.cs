using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console;

public interface ICommandProvider
{
    public bool TryGetCommand([NotNullWhen(true)] out ICommand? command);
}
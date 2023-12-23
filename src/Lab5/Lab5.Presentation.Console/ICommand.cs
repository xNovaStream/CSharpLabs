using System.Threading.Tasks;

namespace Lab5.Presentation.Console;

public interface ICommand
{
    public string Name { get; }
    public Task Run();
}
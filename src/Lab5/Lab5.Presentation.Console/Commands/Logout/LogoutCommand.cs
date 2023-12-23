using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.Logout;

public class LogoutCommand : ICommand
{
    private readonly ICurrentAccountService _currentAccountService;

    public LogoutCommand(ICurrentAccountService currentAccountService)
    {
        _currentAccountService = currentAccountService;
    }

    public string Name => "Logout";

    public Task Run()
    {
        _currentAccountService.Logout();
        AnsiConsole.MarkupLine("[green]Successful logout[/]");
        return Task.CompletedTask;
    }
}
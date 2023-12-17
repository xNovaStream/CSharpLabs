using System;
using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts.Logins;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.Login.Admin;

public class AdminLoginCommand : ICommand
{
    private readonly IAdminLoginService _loginService;

    public AdminLoginCommand(IAdminLoginService loginService)
    {
        ArgumentNullException.ThrowIfNull(loginService);

        _loginService = loginService;
    }

    public string Name => "Admin login";

    public async Task Run()
    {
        string login = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter login")
                .PromptStyle("green"));
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter password")
                .PromptStyle("red")
                .Secret());

        ActionResult result = await _loginService.Login(new AdminAccount(login, password));

        if (result.IsSuccess)
        {
            AnsiConsole.MarkupLine("[green]Successful login[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]{result.ErrorMessage}[/]");
            Environment.Exit(0);
        }
    }
}
using System;
using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts.Creators;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.CreateAccount.Admin;

public class CreateAdminCommand : ICommand
{
    private readonly IAdminCreatorService _creatorService;

    public CreateAdminCommand(IAdminCreatorService creatorService)
    {
        ArgumentNullException.ThrowIfNull(creatorService);

        _creatorService = creatorService;
    }

    public string Name => "Crete admin";

    public async Task Run()
    {
        string login = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter login")
                .PromptStyle("green"));
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter password")
                .PromptStyle("red")
                .Secret());

        ActionResult result = await _creatorService.CreateAccount(new AdminAccount(login, password));

        if (result.IsSuccess)
        {
            AnsiConsole.MarkupLine("Successful created");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]{result.ErrorMessage}[/]");
        }
    }
}
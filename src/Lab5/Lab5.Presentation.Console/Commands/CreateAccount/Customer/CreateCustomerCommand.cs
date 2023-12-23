using System;
using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts.Creators;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.CreateAccount.Customer;

public class CreateCustomerCommand : ICommand
{
    private readonly ICustomerCreatorService _creatorService;

    public CreateCustomerCommand(ICustomerCreatorService creatorService)
    {
        ArgumentNullException.ThrowIfNull(creatorService);

        _creatorService = creatorService;
    }

    public string Name => "Create customer";

    public async Task Run()
    {
        string number = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter account number")
                .PromptStyle("green"));
        string pinCode = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter pin code")
                .PromptStyle("red")
                .Secret());

        ActionResult result = await _creatorService.CreateAccount(new CustomerAccount(number, pinCode));

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
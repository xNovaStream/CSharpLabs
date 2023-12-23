using System;
using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts.Logins;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.Login.Customer;

public class CustomerLoginCommand : ICommand
{
    private readonly ICustomerLoginService _loginService;

    public CustomerLoginCommand(ICustomerLoginService loginService)
    {
        ArgumentNullException.ThrowIfNull(loginService);

        _loginService = loginService;
    }

    public string Name => "Customer login";

    public async Task Run()
    {
        string number = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter bank account number")
                .PromptStyle("green"));
        string pinCode = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter pin code")
                .PromptStyle("red")
                .Secret());

        ActionResult result = await _loginService.Login(new CustomerAccount(number, pinCode));

        if (result.IsSuccess)
        {
            AnsiConsole.MarkupLine("[green]Successful login[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]{result.ErrorMessage}[/]");
        }
    }
}
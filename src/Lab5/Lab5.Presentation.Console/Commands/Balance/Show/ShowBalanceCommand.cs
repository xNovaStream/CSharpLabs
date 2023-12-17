using System;
using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Balances;
using Lab5.Application.Models.Logins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.Balance.Show;

public class ShowBalanceCommand : ICommand
{
    private readonly ICustomerService _customerService;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly ICustomerBalanceService _customerBalanceService;

    public ShowBalanceCommand(
        ICustomerService customerService,
        ICurrentAccountService currentAccountService,
        ICustomerBalanceService customerBalanceService)
    {
        ArgumentNullException.ThrowIfNull(customerService);
        ArgumentNullException.ThrowIfNull(currentAccountService);
        ArgumentNullException.ThrowIfNull(customerBalanceService);

        _customerService = customerService;
        _currentAccountService = currentAccountService;
        _customerBalanceService = customerBalanceService;
    }

    public string Name => "Show balance";

    public async Task Run()
    {
        string number = _currentAccountService.AccessLevel == AccessLevel.Admin
            ? AnsiConsole.Prompt(
                new TextPrompt<string>("Enter customer account's number")
                    .PromptStyle("green"))
            : _currentAccountService.CustomerNumber;

        if (!await _customerService.Exists(number))
        {
            AnsiConsole.MarkupLine("[red]This customer account number doesn't exist[/]");
            return;
        }

        int balance = await _customerBalanceService.GetBalance(number);

        AnsiConsole.MarkupLine($"[green]Balance is {balance}[/]");
    }
}
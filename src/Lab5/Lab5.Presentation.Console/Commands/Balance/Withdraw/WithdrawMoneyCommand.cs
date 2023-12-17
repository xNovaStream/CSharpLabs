using System;
using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts.Balances;
using Lab5.Application.Models.ActionResults;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.Balance.Withdraw;

public class WithdrawMoneyCommand : ICommand
{
    private readonly ICustomerBalanceService _customerBalanceService;

    public WithdrawMoneyCommand(ICustomerBalanceService customerBalanceService)
    {
        ArgumentNullException.ThrowIfNull(customerBalanceService);

        _customerBalanceService = customerBalanceService;
    }

    public string Name => "Withdraw money";

    public async Task Run()
    {
        int changing = AnsiConsole.Prompt(
            new TextPrompt<int>("Enter money count")
                .PromptStyle("green"));

        ActionResult result = await _customerBalanceService.WithdrawMoney(changing);

        if (result.IsSuccess)
        {
            AnsiConsole.MarkupLine("[green]Money successfully withdrawed[/]");
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]{result.ErrorMessage}[/]");
        }
    }
}
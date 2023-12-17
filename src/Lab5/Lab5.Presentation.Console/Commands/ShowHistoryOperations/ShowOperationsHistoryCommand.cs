using System;
using System.Threading.Tasks;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.OperationsHistory;
using Lab5.Application.Models.Logins;
using Lab5.Application.Models.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Commands.ShowHistoryOperations;

public class ShowOperationsHistoryCommand : ICommand
{
    private readonly ICustomerService _customerService;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly IOperationsHistoryService _operationsHistoryService;

    public ShowOperationsHistoryCommand(
        ICustomerService customerService,
        ICurrentAccountService currentAccountService,
        IOperationsHistoryService operationsHistoryService)
    {
        ArgumentNullException.ThrowIfNull(customerService);
        ArgumentNullException.ThrowIfNull(currentAccountService);
        ArgumentNullException.ThrowIfNull(operationsHistoryService);

        _customerService = customerService;
        _currentAccountService = currentAccountService;
        _operationsHistoryService = operationsHistoryService;
    }

    public string Name => "Show history operations";
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

        var table = new Table();
        table.AddColumn("Operation");
        table.AddColumn(new TableColumn("Balance after operation").Centered());

        foreach ((OperationType type, int newBalance) in await _operationsHistoryService.GetCustomerOperations(number))
        {
            table.AddRow($"{type}", $"{newBalance}");
        }

        AnsiConsole.Write(table);
    }
}
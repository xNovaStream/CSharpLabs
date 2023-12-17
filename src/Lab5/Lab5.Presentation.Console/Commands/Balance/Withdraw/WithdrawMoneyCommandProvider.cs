using System;
using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Logins;

namespace Lab5.Presentation.Console.Commands.Balance.Withdraw;

public class WithdrawMoneyCommandProvider : ICommandProvider
{
    private readonly WithdrawMoneyCommand _moneyCommand;
    private readonly ICurrentAccountService _currentAccountService;

    public WithdrawMoneyCommandProvider(WithdrawMoneyCommand moneyCommand, ICurrentAccountService currentAccountService)
    {
        ArgumentNullException.ThrowIfNull(moneyCommand);
        ArgumentNullException.ThrowIfNull(currentAccountService);

        _moneyCommand = moneyCommand;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetCommand([NotNullWhen(true)] out ICommand? command)
    {
        if (_currentAccountService.AccessLevel == AccessLevel.Customer)
        {
            command = _moneyCommand;
            return true;
        }

        command = null;
        return false;
    }
}
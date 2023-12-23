using System;
using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Logins;

namespace Lab5.Presentation.Console.Commands.Login.Customer;

public class CustomerLoginCommandProvider : ICommandProvider
{
    private readonly ICurrentAccountService _currentAccountService;
    private readonly CustomerLoginCommand _command;

    public CustomerLoginCommandProvider(CustomerLoginCommand command, ICurrentAccountService currentAccountService)
    {
        ArgumentNullException.ThrowIfNull(command);
        ArgumentNullException.ThrowIfNull(currentAccountService);

        _command = command;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetCommand([NotNullWhen(true)] out ICommand? command)
    {
        if (_currentAccountService.AccessLevel == AccessLevel.Guest)
        {
            command = _command;
            return true;
        }

        command = null;
        return false;
    }
}
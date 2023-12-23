using System;
using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Logins;

namespace Lab5.Presentation.Console.Commands.CreateAccount.Customer;

public class CreateCustomerCommandProvider : ICommandProvider
{
    private readonly CreateCustomerCommand _command;
    private readonly ICurrentAccountService _currentAccountService;

    public CreateCustomerCommandProvider(CreateCustomerCommand command, ICurrentAccountService currentAccountService)
    {
        ArgumentNullException.ThrowIfNull(command);
        ArgumentNullException.ThrowIfNull(currentAccountService);

        _command = command;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetCommand([NotNullWhen(true)] out ICommand? command)
    {
        if (_currentAccountService.AccessLevel == AccessLevel.Admin)
        {
            command = _command;
            return true;
        }

        command = null;
        return false;
    }
}
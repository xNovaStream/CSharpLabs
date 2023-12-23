using System;
using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Logins;

namespace Lab5.Presentation.Console.Commands.Login.Admin;

public class AdminLoginCommandProvider : ICommandProvider
{
    private readonly ICurrentAccountService _currentAccountService;
    private readonly AdminLoginCommand _command;

    public AdminLoginCommandProvider(AdminLoginCommand command, ICurrentAccountService currentAccountService)
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
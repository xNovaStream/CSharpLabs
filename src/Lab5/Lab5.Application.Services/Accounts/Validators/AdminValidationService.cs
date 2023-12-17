using System;
using System.Linq;
using Lab5.Application.Contracts.Accounts.Validators;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Services.Accounts.Validators;

internal class AdminValidationService : IAdminValidationService
{
    private const int LoginMinLenght = 5;
    private const int LoginMaxLenght = 20;

    private const int PasswordMinLenght = 10;
    private const int PasswordMaxLenght = 50;

    public bool TryValidateLogin(string login, out string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(login);

        if (login.Length is < LoginMinLenght or > LoginMaxLenght)
        {
            errorMessage = $"Login lenght mustn't be less then {LoginMinLenght} and greater then {LoginMaxLenght}";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    public bool TryValidatePassword(string password, out string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(password);

        if (password.Length is < PasswordMinLenght or > PasswordMaxLenght)
        {
            errorMessage =
                $"Password lenght mustn't be less then {PasswordMinLenght} and greater then {PasswordMaxLenght}";
            return false;
        }

        if (!password.Any(char.IsDigit))
        {
            errorMessage = "Password lenght must contains any digit";
            return false;
        }

        if (!password.Any(char.IsUpper))
        {
            errorMessage = "Password lenght must contains any upper char";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    public bool TryValidateAccount(AdminAccount account, out string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(account);

        return TryValidateLogin(account.Login, out errorMessage)
               && TryValidatePassword(account.Password, out errorMessage);
    }
}
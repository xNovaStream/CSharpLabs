using System;
using System.Linq;
using Lab5.Application.Contracts.Accounts.Validators;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Services.Accounts.Validators;

internal class CustomerValidationService : ICustomerValidationService
{
    private const int NumberLenght = 16;
    private const int PinCodeLenght = 4;
    public bool TryValidateNumber(string number, out string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(number);

        if (number.Length != NumberLenght)
        {
            errorMessage = $"Customer number's length must be equal {NumberLenght}";
            return false;
        }

        if (!number.All(char.IsDigit))
        {
            errorMessage = "Customer number must contains only digits";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    public bool TryValidatePinCode(string pinCode, out string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(pinCode);

        if (pinCode.Length != PinCodeLenght)
        {
            errorMessage = $"Pin code's length must be equal {PinCodeLenght}";
            return false;
        }

        if (!pinCode.All(char.IsDigit))
        {
            errorMessage = "Pin code must contains only digits";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }

    public bool TryValidateAccount(CustomerAccount account, out string errorMessage)
    {
        ArgumentNullException.ThrowIfNull(account);

        return TryValidateNumber(account.Number, out errorMessage)
               && TryValidatePinCode(account.PinCode, out errorMessage);
    }
}
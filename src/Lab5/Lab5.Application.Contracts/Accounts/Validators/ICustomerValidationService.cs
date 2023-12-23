using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Contracts.Accounts.Validators;

public interface ICustomerValidationService
{
    public bool TryValidateNumber(string number, out string errorMessage);
    public bool TryValidatePinCode(string pinCode, out string errorMessage);
    public bool TryValidateAccount(CustomerAccount account, out string errorMessage);
}
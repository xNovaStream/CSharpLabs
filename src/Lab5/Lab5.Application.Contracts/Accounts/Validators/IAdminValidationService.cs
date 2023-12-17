using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Contracts.Accounts.Validators;

public interface IAdminValidationService
{
    public bool TryValidateLogin(string login, out string errorMessage);
    public bool TryValidatePassword(string password, out string errorMessage);
    public bool TryValidateAccount(AdminAccount account, out string errorMessage);
}
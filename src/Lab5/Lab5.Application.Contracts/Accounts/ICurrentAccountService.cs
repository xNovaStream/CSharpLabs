using Lab5.Application.Models.Logins;

namespace Lab5.Application.Contracts.Accounts;

public interface ICurrentAccountService
{
    AccessLevel AccessLevel { get; }
    string CustomerNumber { get; }
    public void Logout();
}
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models.Logins;

namespace Lab5.Application.Services.Accounts;

internal class CurrentAccountService : ICurrentAccountService
{
    public AccessLevel AccessLevel { get; set; } = AccessLevel.Guest;
    public string CustomerNumber { get; set; } = string.Empty;

    public void Logout()
    {
        AccessLevel = AccessLevel.Guest;
        CustomerNumber = string.Empty;
    }
}
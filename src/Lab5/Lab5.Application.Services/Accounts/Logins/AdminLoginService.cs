using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts.Logins;
using Lab5.Application.Contracts.Accounts.Validators;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Lab5.Application.Models.Logins;

namespace Lab5.Application.Services.Accounts.Logins;

internal class AdminLoginService : IAdminLoginService
{
    private readonly CurrentAccountService _currentAccountService;
    private readonly IAdminRepository _adminRepository;
    private readonly IAdminValidationService _validationService;

    public AdminLoginService(
        CurrentAccountService currentAccountService,
        IAdminRepository adminRepository,
        IAdminValidationService validationService)
    {
        _currentAccountService = currentAccountService;
        _adminRepository = adminRepository;
        _validationService = validationService;
    }

    public async Task<ActionResult> Login(AdminAccount account)
    {
        if (!_validationService.TryValidateAccount(account, out string errorMessage))
        {
            return new ActionResult(false, errorMessage);
        }

        if (!await _adminRepository.Contains(account))
        {
            return new ActionResult(false, "Invalid login or password");
        }

        _currentAccountService.AccessLevel = AccessLevel.Admin;
        return new ActionResult(true);
    }
}
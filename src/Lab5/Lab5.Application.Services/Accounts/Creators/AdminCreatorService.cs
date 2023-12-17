using System;
using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts.Creators;
using Lab5.Application.Contracts.Accounts.Validators;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;

namespace Lab5.Application.Services.Accounts.Creators;

internal class AdminCreatorService : IAdminCreatorService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IAdminValidationService _validationService;

    public AdminCreatorService(
        IAdminRepository adminRepository,
        IAdminValidationService validationService)
    {
        _adminRepository = adminRepository;
        _validationService = validationService;
    }

    public async Task<ActionResult> CreateAccount(AdminAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        if (_validationService.TryValidateAccount(account, out string errorMessage))
        {
            return new ActionResult(false, errorMessage);
        }

        if (await _adminRepository.ContainsKey(account.Login))
        {
            return new ActionResult(false, $"Admin login {account.Login} is already exist");
        }

        await _adminRepository.Add(account);
        return new ActionResult(true);
    }
}
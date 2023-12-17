using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts.Logins;
using Lab5.Application.Contracts.Accounts.Validators;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Lab5.Application.Models.Logins;

namespace Lab5.Application.Services.Accounts.Logins;

internal class CustomerLoginService : ICustomerLoginService
{
    private readonly CurrentAccountService _currentAccountService;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerValidationService _validationService;

    public CustomerLoginService(
        CurrentAccountService currentAccountService,
        ICustomerRepository customerRepository,
        ICustomerValidationService validationService)
    {
        _currentAccountService = currentAccountService;
        _customerRepository = customerRepository;
        _validationService = validationService;
    }

    public async Task<ActionResult> Login(CustomerAccount account)
    {
        if (!_validationService.TryValidateAccount(account, out string errorMessage))
        {
            return new ActionResult(false, errorMessage);
        }

        if (!await _customerRepository.Contains(account))
        {
            return new ActionResult(false, "Invalid customer account number or pin code");
        }

        _currentAccountService.AccessLevel = AccessLevel.Customer;
        _currentAccountService.CustomerNumber = account.Number;
        return new ActionResult(true);
    }
}
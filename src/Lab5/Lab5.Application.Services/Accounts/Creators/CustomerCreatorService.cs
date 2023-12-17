using System;
using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts.Creators;
using Lab5.Application.Contracts.Accounts.Validators;
using Lab5.Application.Contracts.OperationsHistory;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Services.Accounts.Creators;

internal class CustomerCreatorService : ICustomerCreatorService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerValidationService _validationService;
    private readonly IOperationsHistoryService _operationsHistoryService;

    public CustomerCreatorService(
        ICustomerRepository customerRepository,
        ICustomerValidationService validationService,
        IOperationsHistoryService operationsHistoryService)
    {
        _customerRepository = customerRepository;
        _validationService = validationService;
        _operationsHistoryService = operationsHistoryService;
    }

    public async Task<ActionResult> CreateAccount(CustomerAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        if (!_validationService.TryValidateAccount(account, out string errorMessage))
        {
            return new ActionResult(false, errorMessage);
        }

        if (await _customerRepository.ContainsKey(account.Number))
        {
            return new ActionResult(false, $"Customer account number {account.Number} is already exist");
        }

        await _customerRepository.Add(account);
        await _operationsHistoryService.AddOperation(account.Number, new Operation(OperationType.CreateAccount, 0));
        return new ActionResult(true);
    }
}
using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Balances;
using Lab5.Application.Contracts.OperationsHistory;
using Lab5.Application.Models.ActionResults;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Services.Accounts.Balances;

internal class CustomerBalanceService : ICustomerBalanceService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ICurrentAccountService _currentAccountService;
    private readonly IOperationsHistoryService _operationsHistoryService;

    public CustomerBalanceService(
        ICustomerRepository customerRepository,
        ICurrentAccountService currentAccountService,
        IOperationsHistoryService operationsHistoryService)
    {
        _customerRepository = customerRepository;
        _currentAccountService = currentAccountService;
        _operationsHistoryService = operationsHistoryService;
    }

    public async Task<ActionResult> PutMoney(int changing)
    {
        if (changing < 0)
        {
            return new ActionResult(false, "Changing mustn't be negative");
        }

        await _customerRepository.ChangeBalance(_currentAccountService.CustomerNumber, changing);
        await _operationsHistoryService.AddOperation(
            _currentAccountService.CustomerNumber,
            new Operation(OperationType.PutMoney, await GetBalance()));

        return new ActionResult(true);
    }

    public async Task<ActionResult> WithdrawMoney(int changing)
    {
        if (changing < 0)
        {
            return new ActionResult(false, "Changing mustn't be negative");
        }

        if (await GetBalance(_currentAccountService.CustomerNumber) < changing)
        {
            return new ActionResult(false, "Withdrawable money mustn't be greater then balance");
        }

        await _customerRepository.ChangeBalance(_currentAccountService.CustomerNumber, -changing);
        await _operationsHistoryService.AddOperation(
            _currentAccountService.CustomerNumber,
            new Operation(OperationType.WithdrawMoney, await GetBalance()));
        return new ActionResult(true);
    }

    public Task<int> GetBalance() => GetBalance(_currentAccountService.CustomerNumber);

    public Task<int> GetBalance(string number) => _customerRepository.GetBalance(number);
}
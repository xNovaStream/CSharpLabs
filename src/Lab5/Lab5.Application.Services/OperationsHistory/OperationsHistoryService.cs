using System.Collections.Generic;
using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.OperationsHistory;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Services.OperationsHistory;

internal class OperationsHistoryService : IOperationsHistoryService
{
    private readonly IOperationsHistoryRepository _operationsHistoryRepository;

    public OperationsHistoryService(IOperationsHistoryRepository operationsHistoryRepository)
    {
        _operationsHistoryRepository = operationsHistoryRepository;
    }

    public Task<IReadOnlyList<Operation>> GetCustomerOperations(string number) =>
        _operationsHistoryRepository.GetCustomerOperations(number);

    public Task AddOperation(string customerNumber, Operation operation) =>
        _operationsHistoryRepository.AddOperation(customerNumber, operation);
}
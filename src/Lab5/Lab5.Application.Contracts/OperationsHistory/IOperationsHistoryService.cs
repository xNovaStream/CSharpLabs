using System.Collections.Generic;
using System.Threading.Tasks;
using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.OperationsHistory;

public interface IOperationsHistoryService
{
    public Task<IReadOnlyList<Operation>> GetCustomerOperations(string number);
    public Task AddOperation(string customerNumber, Operation operation);
}
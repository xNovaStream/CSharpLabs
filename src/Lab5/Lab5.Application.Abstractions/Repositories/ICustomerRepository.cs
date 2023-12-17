using System.Threading.Tasks;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface ICustomerRepository
{
    public Task Add(CustomerAccount account);
    public Task<bool> Contains(CustomerAccount account);
    public Task<bool> ContainsKey(string number);
    public Task<int> GetBalance(string number);
    public Task ChangeBalance(string number, int changing);
}
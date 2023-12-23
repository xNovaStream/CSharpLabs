using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;

namespace Lab5.Application.Services.Accounts;

internal class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<bool> Exists(string number)
    {
        return _customerRepository.ContainsKey(number);
    }
}
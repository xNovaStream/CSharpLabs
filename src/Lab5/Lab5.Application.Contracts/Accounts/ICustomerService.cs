using System.Threading.Tasks;

namespace Lab5.Application.Contracts.Accounts;

public interface ICustomerService
{
    public Task<bool> Exists(string number);
}
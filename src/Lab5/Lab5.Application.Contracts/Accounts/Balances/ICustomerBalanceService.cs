using System.Threading.Tasks;
using Lab5.Application.Models.ActionResults;

namespace Lab5.Application.Contracts.Accounts.Balances;

public interface ICustomerBalanceService
{
    public Task<ActionResult> PutMoney(int changing);
    public Task<ActionResult> WithdrawMoney(int changing);
    public Task<int> GetBalance();
    public Task<int> GetBalance(string number);
}
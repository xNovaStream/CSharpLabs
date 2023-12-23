using System.Threading.Tasks;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;

namespace Lab5.Application.Contracts.Accounts.Creators;

public interface IAdminCreatorService
{
    public Task<ActionResult> CreateAccount(AdminAccount account);
}
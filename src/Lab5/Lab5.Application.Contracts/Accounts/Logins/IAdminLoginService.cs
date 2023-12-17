using System.Threading.Tasks;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;

namespace Lab5.Application.Contracts.Accounts.Logins;

public interface IAdminLoginService
{
    public Task<ActionResult> Login(AdminAccount account);
}
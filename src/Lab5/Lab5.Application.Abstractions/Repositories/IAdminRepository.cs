using System.Threading.Tasks;
using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    public Task Add(AdminAccount account);
    public Task<bool> ContainsKey(string login);
    public Task<bool> Contains(AdminAccount account);
}
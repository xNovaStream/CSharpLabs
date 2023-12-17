using System.Threading.Tasks;

namespace Lab5.Presentation.Console.Commands.CreateAccount.Admin;

public class CreateAdminCommand : ICommand
{
    public string Name => "Crete admin";

    public Task Run()
    {
        throw new System.NotImplementedException();
    }
}
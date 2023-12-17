using Lab5.Presentation.Console.Commands.Balance.PutMoney;
using Lab5.Presentation.Console.Commands.Balance.Show;
using Lab5.Presentation.Console.Commands.Balance.Withdraw;
using Lab5.Presentation.Console.Commands.CreateAccount.Admin;
using Lab5.Presentation.Console.Commands.CreateAccount.Customer;
using Lab5.Presentation.Console.Commands.Login.Admin;
using Lab5.Presentation.Console.Commands.Login.Customer;
using Lab5.Presentation.Console.Commands.Logout;
using Lab5.Presentation.Console.Commands.ShowHistoryOperations;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection) =>
        collection
            .AddScoped<CommandRunner>()
            .AddCommands()
            .AddCommandProviders();

    private static IServiceCollection AddCommands(this IServiceCollection collection)
    {
        collection
            .AddScoped<CustomerLoginCommand>()
            .AddScoped<AdminLoginCommand>();

        collection
            .AddScoped<CreateCustomerCommand>()
            .AddScoped<CreateAdminCommand>();

        collection
            .AddScoped<ShowBalanceCommand>()
            .AddScoped<PutMoneyCommand>()
            .AddScoped<WithdrawMoneyCommand>();

        collection.AddScoped<ShowOperationsHistoryCommand>();

        collection.AddScoped<LogoutCommand>();

        return collection;
    }

    private static IServiceCollection AddCommandProviders(this IServiceCollection collection)
    {
        collection
            .AddScoped<ICommandProvider, CustomerLoginCommandProvider>()
            .AddScoped<ICommandProvider, AdminLoginCommandProvider>();

        collection
            .AddScoped<ICommandProvider, CreateCustomerCommandProvider>()
            .AddScoped<ICommandProvider, CreateAdminCommandProvider>();

        collection
            .AddScoped<ICommandProvider, ShowBalanceCommandProvider>()
            .AddScoped<ICommandProvider, PutMoneyCommandProvider>()
            .AddScoped<ICommandProvider, WithdrawMoneyCommandProvider>();

        collection.AddScoped<ICommandProvider, ShowOperationsHistoryCommandProvider>();

        collection.AddScoped<ICommandProvider, LogoutCommandProvider>();

        return collection;
    }
}
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Balances;
using Lab5.Application.Contracts.Accounts.Creators;
using Lab5.Application.Contracts.Accounts.Logins;
using Lab5.Application.Contracts.Accounts.Validators;
using Lab5.Application.Contracts.OperationsHistory;
using Lab5.Application.Services.Accounts;
using Lab5.Application.Services.Accounts.Balances;
using Lab5.Application.Services.Accounts.Creators;
using Lab5.Application.Services.Accounts.Logins;
using Lab5.Application.Services.Accounts.Validators;
using Lab5.Application.Services.OperationsHistory;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Services.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection
            .AddScoped<CurrentAccountService>()
            .AddScoped<ICurrentAccountService>(
                serviceProvider => serviceProvider.GetRequiredService<CurrentAccountService>());

        collection
            .AddScoped<IAdminValidationService, AdminValidationService>()
            .AddScoped<ICustomerValidationService, CustomerValidationService>();

        collection.AddScoped<ICustomerService, CustomerService>();

        collection
            .AddScoped<ICustomerLoginService, CustomerLoginService>()
            .AddScoped<IAdminLoginService, AdminLoginService>();

        collection
            .AddScoped<ICustomerCreatorService, CustomerCreatorService>()
            .AddScoped<IAdminCreatorService, AdminCreatorService>();

        collection.AddScoped<ICustomerBalanceService, CustomerBalanceService>();

        collection.AddScoped<IOperationsHistoryService, OperationsHistoryService>();

        return collection;
    }
}
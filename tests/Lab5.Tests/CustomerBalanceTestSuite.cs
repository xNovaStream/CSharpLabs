using System.Threading.Tasks;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts.Balances;
using Lab5.Application.Contracts.Accounts.Logins;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.ActionResults;
using Lab5.Application.Services.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class CustomerBalanceTestSuite
{
    [Fact]
    public async Task WithdrawMoneyTest()
    {
        // arrange
        ICustomerRepository customerRepository = Substitute.For<ICustomerRepository>();
        IAdminRepository adminRepository = Substitute.For<IAdminRepository>();
        IOperationsHistoryRepository operationsHistoryRepository = Substitute.For<IOperationsHistoryRepository>();

        var account = new CustomerAccount("1234567890123456", "1234");
        const int balance = 50;
        const int validChanging = 25;
        const int invalidChanging = 75;

        customerRepository.ContainsKey(account.Number).Returns(true);
        customerRepository.Contains(account).Returns(true);
        customerRepository.GetBalance(account.Number).Returns(balance);

        var collection = new ServiceCollection();
        collection
            .AddApplication()
            .AddSingleton(customerRepository)
            .AddSingleton(adminRepository)
            .AddSingleton(operationsHistoryRepository);

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        ICustomerBalanceService customerBalanceService =
            scope.ServiceProvider.GetRequiredService<ICustomerBalanceService>();

        await scope.ServiceProvider.GetRequiredService<ICustomerLoginService>().Login(account);

        // act
        ActionResult validWithdrawing = await customerBalanceService.WithdrawMoney(validChanging);
        ActionResult invalidWithdrawing = await customerBalanceService.WithdrawMoney(invalidChanging);

        // assert
        Assert.True(validWithdrawing.IsSuccess);
        Assert.False(invalidWithdrawing.IsSuccess);
    }

    [Fact]
    public async Task PutMoneyTest()
    {
        // arrange
        ICustomerRepository customerRepository = Substitute.For<ICustomerRepository>();
        IAdminRepository adminRepository = Substitute.For<IAdminRepository>();
        IOperationsHistoryRepository operationsHistoryRepository = Substitute.For<IOperationsHistoryRepository>();

        var account = new CustomerAccount("1234567890123456", "1234");
        const int balance = 50;
        const int changing = 25;

        customerRepository.ContainsKey(account.Number).Returns(true);
        customerRepository.Contains(account).Returns(true);
        customerRepository.GetBalance(account.Number).Returns(balance);

        var collection = new ServiceCollection();
        collection
            .AddApplication()
            .AddSingleton(customerRepository)
            .AddSingleton(adminRepository)
            .AddSingleton(operationsHistoryRepository);

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        ICustomerBalanceService customerBalanceService =
            scope.ServiceProvider.GetRequiredService<ICustomerBalanceService>();

        await scope.ServiceProvider.GetRequiredService<ICustomerLoginService>().Login(account);

        // act
        ActionResult puttingMoney = await customerBalanceService.WithdrawMoney(changing);

        // assert
        Assert.True(puttingMoney.IsSuccess);
    }
}
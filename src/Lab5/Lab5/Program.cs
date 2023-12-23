using System.Threading;
using Lab5.Application.Services.Extensions;
using Lab5.Infrastructure.DataAccess.Extensions;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 5432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

await scope.UseInfrastructureDataAccess();

CommandRunner scenarioRunner = scope.ServiceProvider.GetRequiredService<CommandRunner>();

while (true)
{
    await scenarioRunner.Run();
    Thread.Sleep(1500);
    AnsiConsole.Clear();
}
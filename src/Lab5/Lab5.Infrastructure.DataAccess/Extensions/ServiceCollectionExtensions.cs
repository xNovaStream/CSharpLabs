using System;
using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Infrastructure.DataAccess.Plugins;
using Lab5.Infrastructure.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection
            .AddPlatformPostgres(builder => builder.Configure(configuration))
            .AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MappingPlugin>();

        collection
            .AddScoped<ICustomerRepository, CustomerRepository>()
            .AddScoped<IAdminRepository, AdminRepository>()
            .AddScoped<IOperationsHistoryRepository, OperationsHistoryRepository>();

        return collection;
    }
}
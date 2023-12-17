using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Operations;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class OperationsHistoryRepository : IOperationsHistoryRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationsHistoryRepository(IPostgresConnectionProvider connectionProvider)
    {
        ArgumentNullException.ThrowIfNull(connectionProvider);

        _connectionProvider = connectionProvider;
    }

    public async Task<IReadOnlyList<Operation>> GetCustomerOperations(string number)
    {
        ArgumentNullException.ThrowIfNull(number);

        const string sql = """
                           select operation, new_balance
                           from operations_history
                           where :number = customer_number;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("number", number);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var result = new List<Operation>();
        while (await reader.ReadAsync())
        {
            result.Add(new Operation(
                await reader.GetFieldValueAsync<OperationType>(0),
                reader.GetInt32(1)));
        }

        return result;
    }

    public async Task AddOperation(string customerNumber, Operation operation)
    {
        ArgumentNullException.ThrowIfNull(customerNumber);
        ArgumentNullException.ThrowIfNull(operation);

        const string sql = """
                           insert into operations_history
                           (customer_number, operation, new_balance)
                           values
                           (:customer_number, :operation, :new_balance);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("customer_number", customerNumber)
            .AddParameter("operation", operation.Type)
            .AddParameter("new_balance", operation.NewBalance);

        await command.ExecuteNonQueryAsync();
    }
}
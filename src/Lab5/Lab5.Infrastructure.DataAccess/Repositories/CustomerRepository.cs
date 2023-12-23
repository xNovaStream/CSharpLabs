using System;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public CustomerRepository(IPostgresConnectionProvider connectionProvider)
    {
        ArgumentNullException.ThrowIfNull(connectionProvider);

        _connectionProvider = connectionProvider;
    }

    public async Task Add(CustomerAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        const string sql = """
                           insert into customers
                           (number, pin_code, balance)
                           values
                           (:number, :pin_code, 0);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("number", account.Number)
            .AddParameter("pin_code", account.PinCode);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<bool> Contains(CustomerAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        const string sql = """
                           select number
                           from customers
                           where :number = number and :pin_code = pin_code;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("number", account.Number)
            .AddParameter("pin_code", account.PinCode);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync();
    }

    public async Task<bool> ContainsKey(string number)
    {
        ArgumentNullException.ThrowIfNull(number);

        const string sql = """
                           select number
                           from customers
                           where :number = number;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("number", number);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync();
    }

    public async Task<int> GetBalance(string number)
    {
        ArgumentNullException.ThrowIfNull(number);

        const string sql = """
                           select balance
                           from customers
                           where :number = number;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("number", number);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        await reader.ReadAsync();

        return reader.GetInt32(0);
    }

    public async Task ChangeBalance(string number, int changing)
    {
        ArgumentNullException.ThrowIfNull(number);

        const string sql = """
                           update customers
                           set balance = :changing + (
                               select balance
                               from customers
                               where :number = number)
                           where :number = number;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("number", number)
            .AddParameter("changing", changing);

        await command.ExecuteNonQueryAsync();
    }
}
using System;
using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        ArgumentNullException.ThrowIfNull(connectionProvider);

        _connectionProvider = connectionProvider;
    }

    public async Task Add(AdminAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        const string sql = """
                           insert into admins
                           (login, password)
                           values
                           (:login, :password);
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("login", account.Login)
            .AddParameter("password", account.Password);

        await command.ExecuteNonQueryAsync();
    }

    public async Task<bool> ContainsKey(string login)
    {
        ArgumentNullException.ThrowIfNull(login);

        const string sql = """
                           select login
                           from admins
                           where :login = login;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("login", login);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync();
    }

    public async Task<bool> Contains(AdminAccount account)
    {
        ArgumentNullException.ThrowIfNull(account);

        const string sql = """
                           select login
                           from admins
                           where :login = login and :password = password;
                           """;

        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default);

        await using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("login", account.Login)
            .AddParameter("password", account.Password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        return await reader.ReadAsync();
    }
}
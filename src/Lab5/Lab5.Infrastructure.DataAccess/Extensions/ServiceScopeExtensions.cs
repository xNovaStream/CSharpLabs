using System.Threading.Tasks;
using Itmo.Dev.Platform.Postgres.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastructure.DataAccess.Extensions;

public static class ServiceScopeExtensions
{
    public static Task UseInfrastructureDataAccess(this IServiceScope scope)
    {
        return scope.UsePlatformMigrationsAsync(default);
    }
}
using Idempotency.Application.Abstractions.Services;
using Idempotency.Persistance.Context;
using Idempotency.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Idempotency.Persistance;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("ApplicationDb");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString, op => op.EnableRetryOnFailure());
        });

        services.AddScoped<IIdempotencyService, IdempotencyService>();

        return services;
    }
}
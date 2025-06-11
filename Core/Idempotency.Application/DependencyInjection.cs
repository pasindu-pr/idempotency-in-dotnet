﻿using Idempotency.Application.Abstractions.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Idempotency.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(IdempotentCommandPipelineBehavior<,>));

        return services;
    }
}

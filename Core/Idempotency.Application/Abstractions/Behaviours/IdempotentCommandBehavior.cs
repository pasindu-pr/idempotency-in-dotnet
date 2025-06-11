using Idempotency.Application.Abstractions.Commands;
using Idempotency.Application.Abstractions.Services;
using MediatR;

namespace Idempotency.Application.Abstractions.Behaviours;

internal sealed class IdempotentCommandPipelineBehavior<TRequest, TResponse>(IIdempotencyService idempotencyService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IdempotentCommand
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (await idempotencyService.RequestExistsAsync(request.Id))
        {
            return default;
        }

        await idempotencyService.CreateRequestAsync(request.Id, typeof(TRequest).Name);

        var response = await next();

        return response;
    }
}

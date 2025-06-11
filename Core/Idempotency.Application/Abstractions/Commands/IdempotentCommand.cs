using MediatR;

namespace Idempotency.Application.Abstractions.Commands;

public record IdempotentCommand(Guid Id) : IRequest;

using Idempotency.Application.Abstractions.Commands;

namespace Idempotency.Application.Items.Commands;

public record CreateItemCommand(Guid Id, string Name) : IdempotentCommand(Id);

using Idempotency.Application.Items.Commands;
using MediatR;

namespace Idempotency.Application.Items.Handlers;

internal class CreateItemCommandHandler : IRequestHandler<CreateItemCommand>
{
    public async Task Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Creating item with ID: {request.Id}, Name: {request.Name}");

        // Simulate some async work
        await Task.Delay(100, cancellationToken);

        Console.WriteLine($"Item created successfully: {request.Name}");
    }
}

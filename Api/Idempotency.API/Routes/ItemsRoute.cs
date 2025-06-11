using Idempotency.Application.Items.Commands;
using MediatR;

namespace Idempotency.API.Routes;

public static class ItemsRoute
{
    public static void MapItemsRoutes(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/items");

        group.MapPost("/", async (CreateItemDto request, IMediator mediator) =>
        {
            var command = new CreateItemCommand(Guid.NewGuid(), request.Name);
            await mediator.Send(command);
            return Results.Created($"/api/items/{command.Id}", new { Id = command.Id, Name = request.Name });
        })
        .WithName("CreateItem")
        .WithSummary("Create a new item");
    }
}

public record CreateItemDto(string Name);

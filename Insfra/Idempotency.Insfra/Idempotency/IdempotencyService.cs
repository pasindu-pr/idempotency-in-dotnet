using Idempotency.Application.Abstractions.Services;
using Idempotency.Persistance.Context;
using Idempotency.Persistance.Idempotency;
using Microsoft.EntityFrameworkCore;

namespace Idempotency.Persistance.Services;

internal class IdempotencyService(AppDbContext dbContext) : IIdempotencyService
{
    public async Task CreateRequestAsync(Guid requestId, string name)
    {
        dbContext.Set<IdempotencyRequest>().Add(new IdempotencyRequest
        {
            Id = requestId,
            Name = name,
            CreatedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> RequestExistsAsync(Guid requestId)
    {
        return await dbContext
            .Set<IdempotencyRequest>()
            .AnyAsync(ir => ir.Id == requestId);
    }
}

using Idempotency.Persistance.Configurations;
using Idempotency.Persistance.Idempotency;
using Microsoft.EntityFrameworkCore;

namespace Idempotency.Persistance.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    DbSet<IdempotencyRequest> IdempotencyRequest { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IdempotencyRequestConfiguration());
    }
}

namespace Idempotency.Persistance.Idempotency;

public class IdempotencyRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } // optional: e.g., Command name
    public DateTime CreatedAt { get; set; }
}

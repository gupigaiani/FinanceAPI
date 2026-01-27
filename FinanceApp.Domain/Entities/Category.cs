using FinanceApp.Domain.Enums;

namespace FinanceApp.Domain.Entities;

public class Category
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public TransactionType Type { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User User { get; private set; } = null!;
    public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

    protected Category() { }

    public Category(string name, TransactionType type, Guid userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }
}

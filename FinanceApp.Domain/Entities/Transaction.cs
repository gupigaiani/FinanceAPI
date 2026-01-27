using FinanceApp.Domain.Enums;

namespace FinanceApp.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public Guid CategoryId { get; private set; }
    public TransactionType Type { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User User { get; private set; } = null!;
    public Category Category { get; private set; } = null!;

    protected Transaction() { }

    public Transaction(
        Guid userId,
        Guid categoryId,
        TransactionType type,
        decimal amount,
        DateTime date,
        string? description)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        Id = Guid.NewGuid();
        UserId = userId;
        CategoryId = categoryId;
        Type = type;
        Amount = amount;
        Date = date.Date;
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }
}

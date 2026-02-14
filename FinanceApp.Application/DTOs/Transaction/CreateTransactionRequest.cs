using FinanceApp.Domain.Enums;

namespace FinanceApp.Application.DTOs.Transaction;

public class CreateTransactionRequest
{
    public string Name { get; set; } = null!;
    public TransactionType Type { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
}

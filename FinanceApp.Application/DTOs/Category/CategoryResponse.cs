using FinanceApp.Domain.Enums;

namespace FinanceApp.Application.DTOs.Category;

public class CategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
}

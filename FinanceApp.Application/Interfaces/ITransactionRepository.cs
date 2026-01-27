using FinanceApp.Domain.Entities;

namespace FinanceApp.Application.Interfaces;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task<IEnumerable<Transaction>> GetByUserAsync(Guid userId);
}

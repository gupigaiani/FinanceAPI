using FinanceApp.Domain.Entities;

namespace FinanceApp.Application.Interfaces;

public interface ICategoryRepository
{
    Task AddAsync(Category category);

    Task<IEnumerable<Category>> GetByUserIdAsync(Guid userId);

    Task<Category?> GetByIdAsync(Guid id, Guid userId);

    Task DeleteAsync(Category category);
}

using FinanceApp.Domain.Entities;

namespace FinanceApp.Application.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(Guid id);
    Task AddAsync(Category category);
}

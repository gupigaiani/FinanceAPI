using FinanceApp.Application.DTOs.Category;
using FinanceApp.Application.Interfaces;
using FinanceApp.Domain.Entities;

namespace FinanceApp.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CreateAsync(Guid userId, CreateCategoryRequest request)
    {
        var category = new Category(
            request.Name,
            request.Type,
            userId
        );

        await _categoryRepository.AddAsync(category);
    }

    public async Task<IEnumerable<CategoryResponse>> GetAllAsync(Guid userId)
    {
        var categories = await _categoryRepository.GetByUserIdAsync(userId);

        return categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Name = c.Name,
            Type = c.Type,
            CreatedAt = c.CreatedAt
        });
    }
}

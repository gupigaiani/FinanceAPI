using FinanceApp.Application.DTOs.Transaction;
using FinanceApp.Application.Interfaces;
using FinanceApp.Domain.Entities;

namespace FinanceApp.Application.Services;

public class TransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task CreateAsync(Guid userId, CreateTransactionRequest request)
    {
        var transaction = new Transaction(
            userId,
            request.CategoryId,
            request.Name,
            request.Type,
            request.Amount,
            request.Date,
            request.Description
        );

        await _transactionRepository.AddAsync(transaction);
    }

    public async Task<IEnumerable<TransactionResponse>> GetAllAsync(Guid userId)
    {
        var transactions = await _transactionRepository.GetByUserAsync(userId);

        return transactions.Select(t => new TransactionResponse
        {
            Id = t.Id,
            Name = t.Name,
            Type = t.Type,
            CreatedAt = t.CreatedAt
        });
    }
}

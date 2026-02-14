using FinanceApp.Application.DTOs.Transaction;
using FinanceApp.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinanceApp.API.Controllers;

[ApiController]
[Route("api/transactions")]
[Authorize]
public class TransactionsController : ControllerBase
{
    private readonly TransactionService _transactionService;

    public TransactionsController(TransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    // POST /api/transactions
    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionRequest request)
    {
        var userId = GetUserIdFromToken();

        await _transactionService.CreateAsync(userId, request);

        return NoContent();
    }

    // GET /api/transactions
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var userId = GetUserIdFromToken();

        var transactions = await _transactionService.GetAllAsync(userId);

        return Ok(transactions);
    }

    private Guid GetUserIdFromToken()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

        if (userIdClaim == null)
            throw new UnauthorizedAccessException("User not authenticated");

        return Guid.Parse(userIdClaim.Value);
    }
}

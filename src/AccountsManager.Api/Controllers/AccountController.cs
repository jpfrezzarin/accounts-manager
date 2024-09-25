using AccountsManager.Application.Accounts.ViewModels;
using AccountsManager.Domain.Accounts;
using AccountsManager.Domain.Accounts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountsManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(
    IGetAccountByIdUseCase<AccountViewModel> getAccountByIdUseCase,
    IGetAllAccountsUseCase<AccountOnlyViewModel> getAllAccountsUseCase, 
    ICreateAccountUseCase createAccountUseCase, 
    ICreateTransactionUseCase createTransactionUseCase,
    IDeleteTransactionUseCase deleteTransactionUseCase,
    ILogger<AccountController> logger) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<AccountOnlyViewModel>> GetAll()
    {
        return await getAllAccountsUseCase.GetAll();
    }
    
    [HttpPost]
    public async Task<Guid> Create(string name, decimal balance)
    {
        return await createAccountUseCase.Create(name, balance);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<AccountViewModel> GetById(Guid id)
    {
        return await getAccountByIdUseCase.GetById(id);
    }
    
    [HttpPost("{id:guid}/transactions")]
    public async Task<Guid> Create(Guid id, decimal amount, string description, bool income)
    {
        return await createTransactionUseCase.Create(id, amount, description, income);
    }
    
    [HttpDelete("{id:guid}/transactions/{transactionId:guid}")]
    public async Task Delete(Guid id, Guid transactionId)
    {
        await deleteTransactionUseCase.Delete(id, transactionId);
    }
}
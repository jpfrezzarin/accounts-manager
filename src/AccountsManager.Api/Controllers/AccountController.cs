using AccountsManager.Application.Accounts.ViewModels;
using AccountsManager.Domain.Accounts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountsManager.Api.Controllers;

[ApiController]
[Route("[controller]s")]
public class AccountController(
    IGetAccountByIdUseCase<AccountViewModel> getAccountByIdUseCase,
    IGetAllAccountsUseCase<AccountOnlyViewModel> getAllAccountsUseCase, 
    ICreateAccountUseCase createAccountUseCase, 
    IUpdateAccountUseCase updateAccountUseCase,
    ICreateTransactionUseCase createTransactionUseCase,
    IDeleteTransactionUseCase deleteTransactionUseCase,
    ILogger<AccountController> logger) 
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AccountOnlyViewModel>>> GetAll()
    {
        return Ok(await getAllAccountsUseCase.GetAll());
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Create(string name, decimal balance)
    {
        var id = await createAccountUseCase.Create(name, balance);
        return Created(nameof(GetById), id);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AccountViewModel>> GetById(Guid id)
    {
        return Ok(await getAccountByIdUseCase.GetById(id));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, string name)
    {
        await updateAccountUseCase.Update(id, name);
        return NoContent();
    }
    
    [HttpPost("{id:guid}/transactions")]
    public async Task<ActionResult<Guid>> Create(Guid id, decimal amount, string description, bool income)
    {
        var transactionId = await createTransactionUseCase.Create(id, amount, description, income);
        return Created(string.Empty, transactionId);
    }
    
    [HttpDelete("{id:guid}/transactions/{transactionId:guid}")]
    public async Task<ActionResult> Delete(Guid id, Guid transactionId)
    {
        await deleteTransactionUseCase.Delete(id, transactionId);
        return NoContent();
    }
}
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
    IDeleteTransactionUseCase deleteTransactionUseCase) 
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
        return Created(nameof(GetById), new { id });
    }
    
    [HttpGet("{accountId:guid}")]
    public async Task<ActionResult<AccountViewModel>> GetById(Guid accountId)
    {
        return Ok(await getAccountByIdUseCase.GetById(accountId));
    }
    
    [HttpPut("{accountId:guid}")]
    public async Task<ActionResult> Update(Guid accountId, string name)
    {
        await updateAccountUseCase.Update(accountId, name);
        return NoContent();
    }
    
    [HttpPost("{accountId:guid}/transactions")]
    public async Task<ActionResult<Guid>> Create(Guid accountId, decimal amount, string description, bool income)
    {
        var transactionId = await createTransactionUseCase.Create(accountId, amount, description, income);
        return Created(string.Empty, new { id = transactionId });
    }
    
    [HttpDelete("{accountId:guid}/transactions/{transactionId:guid}")]
    public async Task<ActionResult> Delete(Guid accountId, Guid transactionId)
    {
        await deleteTransactionUseCase.Delete(accountId, transactionId);
        return NoContent();
    }
}